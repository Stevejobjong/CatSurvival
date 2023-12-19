using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   
    [Header("DATE")]
    public int year = 2024;
    public int current = 1;
    public int month = 3;
    public int day = 1;
    public int hour = 0;

    [Header("Weather")]
    public float RainProbability = 10;

    [HideInInspector]
    public float WorldTemperature = 0;
    [HideInInspector]
    public float CurrentTemperature = 0;
    [HideInInspector]
    public float IncreaseTemperature = 0;

    //[Header("UI")]


    //[Header("Referencer")]

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스가 생성될 경우 제거
        }
    }

}
