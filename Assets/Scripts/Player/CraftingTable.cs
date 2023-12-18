using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class CraftingTable : MonoBehaviour
{
    public GameObject craftingWindow;

    public static CraftingTable instance;

    private PlayerController controller;

    private void Awake()
    {
        instance = this;
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
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
