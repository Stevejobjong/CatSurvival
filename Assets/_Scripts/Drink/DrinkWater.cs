using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrinkWater : MonoBehaviour
{
    public TextMeshProUGUI promptText;


    private void Awake()
    {
        //condition = PlayerConditions.
    }
    private void Start()
    {
        promptText = GameManager.Instance._UI.transform.Find("HUD_Canvas/DrinkText").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.gameObject.SetActive(true);
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
            promptText.gameObject.SetActive(false);
        }
            
    }
}
