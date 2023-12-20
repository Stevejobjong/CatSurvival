using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftTabButton : MonoBehaviour
{
    private Button craftTabSelectBtn;
    [SerializeField] private GameObject craftInforPanel;

    private void Start()
    {
        craftInforPanel.SetActive(false);
        craftTabSelectBtn = GetComponent<Button>();
        craftTabSelectBtn?.onClick.AddListener(() => OpenPanel());
    }

    public void OpenPanel()
    {
        craftInforPanel.SetActive(true);
    }
}
