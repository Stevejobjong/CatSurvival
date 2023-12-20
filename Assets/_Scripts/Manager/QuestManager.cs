using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TMP_Text questText;
    [HideInInspector] public bool fishing;
    [HideInInspector] public bool drink;
    [HideInInspector] public bool isMakeAxe;
    [HideInInspector] public bool isMakePick;
    [HideInInspector] public bool isMakeFishingRod;
    [HideInInspector] public bool felling;
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
        fishing = false;
        drink = false;
    }

    void Start()
    {
        questText = GameManager.Instance._UI.transform.Find("HUD_Canvas/QuestPanel/QuestText").GetComponent<TMP_Text>();
        DrinkWaterQuest(drink);
    }

    public void DrinkWaterQuest(bool clear)
    {
        questText.text = "물가로 가서 물 마시기";

        if (clear)
        {
            questText.text = "퀘스트 완료!";
            Invoke("EndDrinkQuest", 3f);
            //낚시대 보상 추가하면 좋을듯??
        }
    }

    void EndDrinkQuest()
    {
        isMakeAxe = false;
        MakeAxe(isMakeAxe);
    }

    public void MakeAxe(bool clear)
    {
        questText.text = "\"R\"을 눌러 도끼 만들기";
        if (clear)
        {
            questText.text = "퀘스트 완료!";
            Invoke("EndMakeAxe", 3f);
        }
    }
        
    void EndMakeAxe()
    {
        Felling(felling, QuestCount);
    }

    public void Felling(bool clear, int count) //벌목
    {
        questText.text = "도끼로 나무 베기 (" + count + "/5)";
        if (clear)
        {
            questText.text = "퀘스트 완료!";
            Invoke("EndFelling", 3f);
        }
    }

    void EndFelling()
    {
        isMakePick = false;
        MakePick(isMakePick);
    }

    public void MakePick(bool clear)
    {
        questText.text = "\"R\"을 눌러 곡괭이 만들기";
        if (clear)
        {
            questText.text = "퀘스트 완료!";
            Invoke("EndMakePick", 3f);
        }
    }

    void EndMakePick()
    {
        isMakeFishingRod = false;
        MakeFishingRod(isMakeFishingRod);
    }


    public void MakeFishingRod(bool clear)
    {
        questText.text = "\"R\"을 눌러 낚시대 만들기";
        if (clear)
        {
            questText.text = "퀘스트 완료!";
            Invoke("EndMakeFishingRod", 3f);
        }
    }

    void EndMakeFishingRod()
    {
        FishingQuest(fishing, QuestCount);
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
