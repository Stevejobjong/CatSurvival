using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingTable : MonoBehaviour
{
    public GameObject craftingWindow;

    private PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        
        craftingWindow = GameManager.Instance._UI.transform.Find("Crafting/CraftingCanvas").gameObject;
        craftingWindow.SetActive(false);
    }

    public void OnCraftingTableButton(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (craftingWindow.activeInHierarchy)
        {
            craftingWindow.SetActive(false);
            controller.ToggleCursor(false);
        }
        else
        {
            craftingWindow.SetActive(true);
            controller.ToggleCursor(true);
        }
    }

    public bool IsOpen()
    {
        return craftingWindow.activeInHierarchy;
    }
}
