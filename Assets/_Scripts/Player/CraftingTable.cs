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

    //[Header("selected item")]
    //private CraftTab selectedtab;
    //public TextMeshProUGUI selectedcraftname;
    //public TextMeshProUGUI selectedcraftdescription;
    //public TextMeshProUGUI selectedcraftingrediants;
    //public GameObject createbutton;

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
    //    selectedcraftname.text = selectedtab.craft.craftName;
    //    selectedcraftdescription.text = selectedtab.craft.description;
    //    selectedcraftingrediants.text = selectedtab.craft.ingrediants;
    //    if (tabs[index].craft == null)
    //    {
    //        selectedtab = tabs[index];

    //        selectedcraftname.text = selectedtab.craft.craftName;
    //        selectedcraftdescription.text = selectedtab.craft.description;
    //        selectedcraftingrediants.text = selectedtab.craft.ingrediants;
    //    }
    //}
}
