using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public ItemData Scrap;
    public GameObject AirplaneFixPanel;
    
    TMP_Text scrapCount;

    private void Start()
    {
        AirplaneFixPanel = GameManager.Instance._UI.transform.Find("HUD_Canvas/AirplaneFixPanel").gameObject;
        //scarpCount.Text = "0/5" 이런식으로
        scrapCount = AirplaneFixPanel.transform.Find("RepairBG/RepairPanel/Count").GetComponent<TMP_Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            AirplaneFixPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            AirplaneFixPanel.SetActive(false);
        }
    }
}
