using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TMP_Text questText;
    [HideInInspector] public bool Fishing;
    [HideInInspector] public bool Drink;
    [HideInInspector] public int QuestCount;

    public static QuestManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ResetCount();
    }

    void ResetCount()
    {
        Fishing = false;
        Drink = false;
    }

    void Start()
    {
        questText = GameManager.Instance._UI.transform.Find("HUD_Canvas/QuestPanel/QuestText").GetComponent<TMP_Text>();
        DrinkWaterQuest(Drink);
    }


    public void DrinkWaterQuest(bool clear)
    {
        questText.text = "물가로 가서 물 마시기";

        if (clear)
        {
            questText.text = "퀘스트 완료!";
            Invoke("EndDrinkQuest", 3f);            
        }
    }
    void EndDrinkQuest()
    {
        FishingQuest(Fishing, QuestCount);
    }

    public void FishingQuest(bool clear, int count)
    {
        Debug.Log("Fishing");
        questText.text = "낚시하기 (" + count + "/6)";
        if (clear)
        {
            questText.text = "퀘스트 완료!";
            Invoke("EndFishingQuest", 3f);
            QuestCount = 0;
            //다음 퀘스트
        }

    }
    void EndFishingQuest()
    {
        Ending();
    }
    // 기타 퀘스트들 


    public void Ending()
    {
        questText.text = "탈출하기";
    }

}
