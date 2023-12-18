using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateManager : MonoBehaviour
{
    public TMP_Text time;
    public TMP_Text Temperature;
    private int year = 2024;
    private int current = 1;
    private int month = 3;
    public float temperatureDifference = 10.0f;

    public DayNightCycle dayNightCycle;
    public Season season;

    private void Start()
    {
        dayNightCycle = FindObjectOfType<DayNightCycle>();
        season = FindObjectOfType<Season>();
    }

    private void Update()
    {
        Date();
        season.SeasonalChanges();
        _Temperature();
    }

    void _Temperature()
    {
        float currentTemperature = season.GetTemperatureForMonth(month);
        int hour = (int)(dayNightCycle.time * 24);

        float minHour = 2f; // 온도가 최저일 때의 시간
        float maxHour = 14f; // 온도가 최고일 때의 시간

        float startTemperature = season.GetTemperatureForMonth(month) - temperatureDifference / 2; // 최저 온도
        float endTemperature = season.GetTemperatureForMonth(month) + temperatureDifference / 2; // 최고 온도

        float normalizedTime;

        if (hour < minHour)
        {
            normalizedTime = Mathf.InverseLerp(0f, minHour, hour);
            currentTemperature = Mathf.Lerp(currentTemperature, startTemperature, normalizedTime);
        }
        else if (hour >= minHour && hour <= maxHour)
        {
            normalizedTime = Mathf.InverseLerp(minHour, maxHour, hour);
            currentTemperature = Mathf.Lerp(startTemperature, endTemperature, normalizedTime);
        }
        else
        {
            normalizedTime = Mathf.InverseLerp(maxHour, 24f, hour);
            currentTemperature = Mathf.Lerp(endTemperature, currentTemperature, normalizedTime);
        }

        Temperature.text = $"{Mathf.RoundToInt(currentTemperature)} °C";
    }
    void Date()
    {
        int hour = (int)(dayNightCycle.time * 24);
        int day = current + dayNightCycle.day * 3;
        
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if (day > 31)
            {
                current = day - 31;
                dayNightCycle.day = 0;
                month++;
            }
        }
        else if(month == 2)
        {
            if (day > 28)
            {
                current = day - 28;
                dayNightCycle.day = 0;
                month++;
            }
        }
        else
        {
            if (day > 30)
            {
                current = day - 30;
                dayNightCycle.day = 0;
                month++;
            }
        }

        if (month == 13)
        {
            year++;
            month = 1;
        }
        time.text = ($"{year}year {month}month {day}day {hour}hour");
    }

}
