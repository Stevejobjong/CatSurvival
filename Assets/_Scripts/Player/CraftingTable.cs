using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CraftTab
{
    public CraftData craft;
}

public class CraftingTable : MonoBehaviour
{
    //public CraftTab[] tabs;

    public GameObject craftingWindow;

    private PlayerController controller;

    //[Header("Selected Item")]
    //private CraftTab selectedTab;
    //public TextMeshProUGUI selectedCraftName;
    //public TextMeshProUGUI selectedCraftDescription;
    //public TextMeshProUGUI selectedCraftIngrediants;
    //public GameObject createButton;

    [Header("Events")]
    public UnityEvent onOpenCraftingWindow;
    public UnityEvent onCloseCraftingWindow;

    public static CraftingTable instance;

    private void Awake()
    {
        instance = this;
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        
        craftingWindow = GameManager.Instance._UI.transform.Find("Crafting/CraftingCanvas").gameObject;
        craftingWindow.SetActive(false);


        //for (int i = 0; i < tabs.Length; i++)
        //{
        //    tabs[i] = new CraftTab();
        //}
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
            onCloseCraftingWindow?.Invoke();
        }
        else
        {
            craftingWindow.SetActive(true);
            controller.ToggleCursor(true);
            onOpenCraftingWindow?.Invoke();
        }
    }

    public bool IsOpen()
    {
        return craftingWindow.activeInHierarchy;
    }

    //public void BuildCraft(int index)
    //{
    //    selectedCraftName.text = selectedTab.craft.craftName;
    //    selectedCraftDescription.text = selectedTab.craft.description;
    //    selectedCraftIngrediants.text = selectedTab.craft.ingrediants;
    //    if (tabs[index].craft == null)
    //    {
    //        selectedTab = tabs[index];

    //        selectedCraftName.text = selectedTab.craft.craftName;
    //        selectedCraftDescription.text = selectedTab.craft.description;
    //        selectedCraftIngrediants.text = selectedTab.craft.ingrediants;
    //    }
    //}
}
