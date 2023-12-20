using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Airplane : MonoBehaviour
{
    public ItemData Scrap;
    public GameObject AirplaneFixPanel;
    public Button RepairBtn;
    
    TMP_Text scrapCount;
    int count;

    private void Start()
    {
        AirplaneFixPanel = GameManager.Instance._UI.transform.Find("HUD_Canvas/AirplaneFixPanel").gameObject;
        //scarpCount.Text = "0/5" 이런식으로
        scrapCount = AirplaneFixPanel.transform.Find("RepairBG/RepairPanel/Count").GetComponent<TMP_Text>();
        RepairBtn = AirplaneFixPanel.transform.Find("RepairBG/RepairPanel/RepairButton").GetComponent<Button>();
        RepairBtn.onClick.AddListener(ClickRepairBtn);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Debug.Log("비행기에 접근");
            CheckScrap(); //고철 개수 체크
            PlayerController.instance.ToggleCursor(true);
            AirplaneFixPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            Debug.Log("비행기에서 멀어짐");
            PlayerController.instance.ToggleCursor(false);
            AirplaneFixPanel.SetActive(false);
        }
    }
    
    private void CheckScrap()
    {        
        count = Inventory.instance.CheckItemCount(Scrap);
        scrapCount.text = $"{count}/5";
        if (count >= 5)
        {
            bool clear = true;
            QuestManager.Instance.EndingQuest(clear);
        }
    }

    private void ClickRepairBtn()
    {        
        if(count >= 5)
        {
            SceneManager.LoadScene("Scene_Success");
        }
    }
}
