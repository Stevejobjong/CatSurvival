using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    //public GameObject ConditionPrefab;
    //public Transform ConditionParent;

    //[HideInInspector] public Image health;
    //[HideInInspector] public Image hunger;
    //[HideInInspector] public Image thirsty;
    //[HideInInspector] public Image stamina;

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
        
        //GameObject condition = Instantiate(ConditionPrefab, ConditionParent);
        //SetImage(condition);

    }
    //void SetImage(GameObject gameObject)
    //{
    //    hunger = gameObject.transform.Find("HungerImage").GetComponent<Image>();
    //    thirsty = gameObject.transform.Find("ThirstyImage").GetComponent<Image>();
    //    stamina = gameObject.transform.Find("StaminaImage").GetComponent<Image>();
    //    health = gameObject.transform.Find("HealthImage").GetComponent<Image>();
    //}
}
