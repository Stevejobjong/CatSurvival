using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

[System.Serializable]
public class Condition
{
    //[HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar;

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }

}


public class PlayerConditions : MonoBehaviour, IDamagable
{
    public Condition health;
    public Condition hunger;
    public Condition stamina;
    public Condition thirsty;
    public Condition temperature;

    public bool isCold;
    public bool isHot;
    public bool isWet;

    public float StandardResistance = 2;
    public float noHungerHealthDecay;
    public float WetTemperature = 0;
    public float Clothes = 0;

    public UnityEvent onTakeDamage;

    void Start()
    {
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        stamina.curValue = stamina.startValue;
        thirsty.curValue = thirsty.startValue;
        temperature.curValue = temperature.startValue;

        onTakeDamage.AddListener(GameManager.Instance._UI.transform.Find("HUD_Canvas/DamageIndicator").GetComponent<DamageIndicator>().Flash);
        
        health.uiBar = UIManager.Instance.health;
        hunger.uiBar = UIManager.Instance.hunger;
        thirsty.uiBar = UIManager.Instance.thirsty;
        stamina.uiBar = UIManager.Instance.stamina;
        temperature.uiBar = UIManager.Instance.temperature;
    }

    // Update is called once per frame
    void Update()
    {
        _365();
        Hot();
        Cold();

        hunger.Subtract(hunger.decayRate * Time.deltaTime);
        thirsty.Subtract(thirsty.decayRate * Time.deltaTime);
        stamina.Add(stamina.regenRate * Time.deltaTime);

        if (hunger.curValue == 0.0f)
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        if (thirsty.curValue == 0.0f)
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        // 배고픔 혹은 목마름 둘 중 하나라도 0이될 경우 체력 감소

        if (health.curValue == 0.0f)
            Die();


        health.uiBar.fillAmount = health.GetPercentage();
        hunger.uiBar.fillAmount = hunger.GetPercentage();
        thirsty.uiBar.fillAmount = thirsty.GetPercentage();
        stamina.uiBar.fillAmount = stamina.GetPercentage();
        temperature.uiBar.fillAmount = temperature.GetPercentage();
    }
    

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void Drink(float amount)
    {
        thirsty.Add(amount);
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0)
            return false;

        stamina.Subtract(amount);
        return true;
    }

    //36.5도로 보정하는 메서드
    void _365()
    {
        if (temperature.curValue < temperature.startValue)
            temperature.Add(temperature.regenRate * Time.deltaTime);
        if (temperature.curValue > temperature.startValue)
            temperature.Subtract(temperature.regenRate * Time.deltaTime);
    }
    //curValue에 감소되는 값 (월드온도가 높거나 낮은 만큼 * 저항값해서 감소)
    float TemperatureDifferential(float temperature, float Resistance)
    {
        if (GameManager.Instance.CurrentTemperature > temperature)
            return (GameManager.Instance.CurrentTemperature - temperature) * TemperatureResistance(Resistance);
        else
            return (temperature - GameManager.Instance.CurrentTemperature) * TemperatureResistance(Resistance);
    }

    //온도 저항(옷같은거)
    public float TemperatureResistance(float Resistance)
    {
        if ((float)((StandardResistance + Resistance) * 0.1) > 1.0f)
        {
            return 1;
        }
        else
            return 1 - (float)((StandardResistance + Resistance) * 0.1);
    }


    void Cold()
    {
        if (temperature.curValue > GameManager.Instance.CurrentTemperature)
        {
            temperature.Subtract(TemperatureDifferential(temperature.curValue, Clothes)* Time.deltaTime);
        }
        if (temperature.curValue < 32.0f)
        {
            health.Subtract(temperature.decayRate * Time.deltaTime);
        }
    }

    void Hot()
    {
        if (temperature.curValue > GameManager.Instance.CurrentTemperature)
        {
            temperature.Add(TemperatureDifferential(temperature.curValue, Clothes) * Time.deltaTime);
        }
        //(temperature.curValue > 41.0f)

    }

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}