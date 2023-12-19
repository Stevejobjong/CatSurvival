using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject ConditionPrefab;
    public Transform ConditionParent;

    [HideInInspector] public Image health;
    [HideInInspector] public Image hunger;
    [HideInInspector] public Image thirsty;
    [HideInInspector] public Image stamina;
    [HideInInspector] public Image temperature;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스가 생성될 경우 제거
        }

        GameObject condition = Instantiate(ConditionPrefab, ConditionParent); //시작시 condition추가

        SetImage();

    }
    void SetImage()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("ConditionUI");
        for (int i = 0; i < go.Length; i++)
        {
            switch (go[i].name)
            {
                case "HungerImage":
                    hunger = go[i].GetComponent<Image>();
                    break;
                case "ThirstyImage":
                    thirsty = go[i].GetComponent<Image>();
                    break;
                case "StaminaImage":
                    stamina = go[i].GetComponent<Image>();
                    break;
                case "HealthImage":
                    health = go[i].GetComponent<Image>();
                    break;
                case "TemperatureImage":
                    temperature = go[i].GetComponent<Image>();
                    break;
            }
        }
    }
}
