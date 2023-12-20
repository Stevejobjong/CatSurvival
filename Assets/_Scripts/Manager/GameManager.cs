using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public GameObject enemySpawn;

    [Header("Scene")]
    public GameObject _Player;
    //public GameObject _NPC;
    public GameObject _Resources;
    public GameObject _CampFire;
    public GameObject _EventSystem;
    public GameObject _Airplane;
    public GameObject _Environments;
    public GameObject _UI;
    public GameObject _Fishingrod;
    public GameObject _Pickaxe;
    public GameObject _Rain;
   
    [Header("Date")]
    public int year = 2024;
    public int current = 1;
    public int month = 3;
    public int day = 1;
    public int hour = 0;
    public int minute = 0;

    [Header("Weather")]
    public float RainProbability = 10;

    [HideInInspector]
    public float WorldTemperature = 0;
    [HideInInspector]
    public float CurrentTemperature = 0;
    [HideInInspector]
    public float IncreaseTemperature = 0;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        InitSceneInstance();
    }

    private void InitSceneInstance()
    {
        _Player = Instantiate(_Player, new Vector3(47f, 4.3f, 6.24f), Quaternion.Euler(new Vector3(0,-152f,0)));
        //_NPC = Instantiate(_NPC, new Vector3(4.57f, 0f, 6.02f), Quaternion.identity);
        _Resources = Instantiate(_Resources);
        _CampFire = Instantiate(_CampFire, new Vector3(39.2f, 4f, 1.76f), Quaternion.identity);
        _EventSystem = Instantiate(_EventSystem);
        _Airplane = Instantiate(_Airplane, new Vector3(43.81f, 3.81f, 4.72f), Quaternion.identity);
        _Environments = Instantiate(_Environments);
        _UI = Instantiate(_UI);
        _Fishingrod = Instantiate(_Fishingrod, new Vector3(14.2f, 0.2f, 33.61f), Quaternion.identity);
        _Pickaxe = Instantiate(_Pickaxe, new Vector3(13.2f, 0.2f, 33.61f), Quaternion.identity);

        //enemySpawn = Instantiate(enemySpawn, Vector3.zero, Quaternion.identity);
    }
}
