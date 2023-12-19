using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TMP_Text questText;
    public int NumberForDone;
    //private int Quests;

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
        NumberForDone = 0;
    }
    void CompleteQuest()
    {
        //Quests++;
        questText.text = "����Ʈ �Ϸ�!";
        NumberForDone = 0; //�ʱ�ȭ


        //string Questnum = Quests.ToString();
        //string QuestName = "NewQuest" + Questnum;
        //Invoke(QuestName, 3f);
    }

    void Start()
    {
        FishingQuest(NumberForDone);
    }

    //void NewQuest1(int num)
    //{
    //    if (num > 6)
    //    {
    //        CompleteQuest();
    //    }
    //    questText.text = "�����ϱ�" + num + " /6";
    //}


    public void FishingQuest(int num)
    {
        Debug.Log("Fishing");
        questText.text = "�����ϱ� (" + num + "/6)";
        if (num > 5)
        {
            CompleteQuest();
        }
        
    }
    // ��Ÿ ����Ʈ�� �� �ڸ�


    public void Ending()
    {
        questText.text = "Ż���ϱ�";
    }

}
