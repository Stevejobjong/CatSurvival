using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class CraftTabUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    private Outline outline;
    private CraftTab curTab;
    public int thisIcon;
    [SerializeField]private CraftBuild craftBuild;
    public TMP_Text selectedcraftname;
    public TMP_Text selectedcraftdescription;
    public TMP_Text selectedcraftingrediants;

    public bool equipped;

    public GameObject craftInforPanel;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void Start()
    {
        craftInforPanel.SetActive(false);
    }

    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    public void Set(CraftTab tab)
    {
        curTab = tab;
        icon.gameObject.SetActive(true);
        icon.sprite = tab.craft.icon;

        if (outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void Clear()
    {
        curTab = null;
        icon.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (craftInforPanel.activeInHierarchy)
        {
            craftInforPanel.SetActive(false);
        }
        else
        {
            craftInforPanel.SetActive(true);
        }

        craftBuild.craftNum = thisIcon;
        selectedcraftname.text = craftBuild.crafts[thisIcon].craft.craftName;
        selectedcraftdescription.text = craftBuild.crafts[thisIcon].craft.description;
        selectedcraftingrediants.text = craftBuild.crafts[thisIcon].craft.ingrediants;

    }
}
