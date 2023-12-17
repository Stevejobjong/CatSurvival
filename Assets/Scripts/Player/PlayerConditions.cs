using System.Collections;
using System.Collections.Generic;
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

    public float noHungerHealthDecay;

    public UnityEvent onTakeDamage;

    void Start()
    {
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        stamina.curValue = stamina.startValue;
        thirsty.curValue = thirsty.startValue;
    }

    // Update is called once per frame
    void Update()
    {
        hunger.Subtract(hunger.decayRate * Time.deltaTime);
        thirsty.Subtract(thirsty.decayRate * Time.deltaTime);
        stamina.Add(stamina.regenRate * Time.deltaTime);

        if (hunger.curValue == 0.0f ) // 배고픔 혹은 목마름 둘 중 하나라도 0이될 경우 체력 감소
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        if (thirsty.curValue == 0.0f) // 배고픔 혹은 목마름 둘 중 하나라도 0이될 경우 체력 감소
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        if (health.curValue == 0.0f)
            Die();

        //health.uiBar = UIManager.Instance.health;
        //hunger.uiBar = UIManager.Instance.hunger;
        //thirsty.uiBar = UIManager.Instance.thirsty;
        //stamina.uiBar = UIManager.Instance.stamina;

        health.uiBar.fillAmount = health.GetPercentage();        
        hunger.uiBar.fillAmount = hunger.GetPercentage();        
        thirsty.uiBar.fillAmount = thirsty.GetPercentage();        
        stamina.uiBar.fillAmount = stamina.GetPercentage();
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