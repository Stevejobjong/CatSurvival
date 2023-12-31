﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrinkWater : MonoBehaviour
{
    public TextMeshProUGUI drinkText;
    private bool active;
    private void Awake()
    {
        active = false;
    }
    private void Start()
    {
        drinkText = GameManager.Instance._UI.transform.Find("HUD_Canvas/DrinkText").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            drinkText.gameObject.SetActive(true);
            active = true;
        }        
    }
    public void OnInteract(InputAction.CallbackContext context)
    {

        if (context.performed && active)
        {
            //물마시기 퀘스트
            if (QuestManager.Instance.drink == false)
            {
                QuestManager.Instance.drink = true;
                QuestManager.Instance.DrinkWaterQuest(QuestManager.Instance.drink);
            }
            PlayerController.instance.condition.Drink(30.0f);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            drinkText.gameObject.SetActive(false);
            active = false;
        }
            
    }
}
