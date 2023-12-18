using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class CraftTabUI : MonoBehaviour
{
    private bool isActivated = false;
    [SerializeField] private GameObject craftingUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CraftWindow();
        }
    }

    private void CraftWindow()
    {
        if (!isActivated)
        {
            OpenCraftWindow();
        }
        else
        {
            ClosedCraftWindow();
        }
    }

    private void OpenCraftWindow()
    {
        isActivated = true;
        craftingUI.SetActive(true);
    }

    private void ClosedCraftWindow()
    {
        isActivated = false;
        craftingUI.SetActive(false);
    }
}
