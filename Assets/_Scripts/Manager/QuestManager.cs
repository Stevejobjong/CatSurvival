using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TMP_Text questText;

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
    }

    void Start()
    {
        questText.text = "�����ϱ�";
    }
    // ��Ÿ ����Ʈ�� �� �ڸ�


    void Ending()
    {
        questText.text = "Ż���ϱ�";
    }

}
