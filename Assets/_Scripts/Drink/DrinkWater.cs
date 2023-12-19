using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrinkWater : MonoBehaviour
{
    public TextMeshProUGUI drinkText;


    private void Awake()
    {
        //condition = PlayerConditions.
    }
    private void Start()
    {
        drinkText = GameManager.Instance._UI.transform.Find("HUD_Canvas/DrinkText").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            drinkText.gameObject.SetActive(true);
        }        
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerController.instance.condition.Drink(10.0f);
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            drinkText.gameObject.SetActive(false);
        }
            
    }
}
