using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrinkWater : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private bool active;

    private void Awake()
    {
        active = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.gameObject.SetActive(true);
            active = true;
        }        
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && active)
        {
            //물마시기 퀘스트
            if (QuestManager.Instance.Drink == false)
            {
                QuestManager.Instance.Drink = true;
                QuestManager.Instance.DrinkWaterQuest(QuestManager.Instance.Drink);
            }
            PlayerController.instance.condition.Drink(10.0f);
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.gameObject.SetActive(false);
            active = false;
        }
            
    }
}
