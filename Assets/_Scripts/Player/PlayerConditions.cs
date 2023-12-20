using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public UnityEvent onTakeDamage;

    void Start()
    {
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        stamina.curValue = stamina.startValue;
        thirsty.curValue = thirsty.startValue;
        temperature.curValue = temperature.startValue;



        health.uiBar = UIManager.Instance.health;
        hunger.uiBar = UIManager.Instance.hunger;
        thirsty.uiBar = UIManager.Instance.thirsty;
        stamina.uiBar = UIManager.Instance.stamina;
        temperature.uiBar = UIManager.Instance.temperature;
    }

    // Update is called once per frame
    void Update()
    {
        hunger.Subtract(hunger.decayRate * Time.deltaTime);
        thirsty.Subtract(thirsty.decayRate * Time.deltaTime);
        stamina.Add(stamina.regenRate * Time.deltaTime);
        //36.5도 유지하는 메서드
        if (temperature.curValue > temperature.startValue)
            temperature.Subtract(temperature.regenRate * Time.deltaTime);
        if (temperature.curValue < temperature.startValue)
            temperature.Add(temperature.regenRate * Time.deltaTime);

        if (hunger.curValue == 0.0f)
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        if (thirsty.curValue == 0.0f)
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        // 배고픔 혹은 목마름 둘 중 하나라도 0이될 경우 체력 감소
        if (isCold == true)
            Debug.Log("춥다");
        health.Subtract(TemperatureDifferential(temperature.startValue, StandardResistance) * Time.deltaTime);
        if (health.curValue == 0.0f)
            Die();

        //저체온증 기믹 추가예정
        //ColdtemperatureRegulation(temperature.decayRate * Time.deltaTime, temperature.regenRate * Time.deltaTime, isWet);



        health.uiBar.fillAmount = health.GetPercentage();
        hunger.uiBar.fillAmount = hunger.GetPercentage();
        thirsty.uiBar.fillAmount = thirsty.GetPercentage();
        stamina.uiBar.fillAmount = stamina.GetPercentage();
        temperature.uiBar.fillAmount = temperature.GetPercentage();

        Heatstrok();
        hypothermia();
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

    //일단 curValue값 변화를 주고 = curvalue 증감 함수가 따로 있으니 그걸 넣고 그 증감은 DIffetential로 하고  health에 데미지는 isCold가 켜졌을때 데미지, 데미지양은 얼마나 춥고 덥냐

    //외부온도가 높거나 낮으면 조금 영향
    float TemperatureDifferential(float temperature, float Resistance)
    {
        if (GameManager.Instance.CurrentTemperature < temperature)
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

    void Heatstrok()
    {
        if (temperature.curValue > 41.0f)
            isHot = true;
        else
            isHot = false;
    }

    void hypothermia()
    {
        if (temperature.curValue < 32.0f)
            isCold = true;
        else
            isCold = false;
    }


    //public void ColdtemperatureRegulation(float decrease, float increased, bool isWet) //온도 조절
    //{
    //    if (isWet)
    //    {
    //        temperature.Subtract(decrease);
    //    }
    //    else
    //    {
    //        if (temperature.curValue < 36.3f)
    //        {
    //            temperature.Add(increased);
    //        }
    //    }

    //}

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