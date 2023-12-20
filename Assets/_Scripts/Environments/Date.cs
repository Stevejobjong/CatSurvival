using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Date : MonoBehaviour
{
    public TMP_Text dateUI;

    private int current = 0;

    private void Update()
    {
        _Date();
    }
    public void _Date()
    {
        int year = GameManager.Instance.year;
        int month = GameManager.Instance.month;
        int hour = GameManager.Instance.hour;
        int day = current + GameManager.Instance.day * 3;

        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if (day > 31)
            {
                current = day - 31;
                GameManager.Instance.day = 0;
                month++;
            }
        }
        else if(month == 2)
        {
            if (day > 28)
            {
                current = day - 28;
                GameManager.Instance.day = 0;
                month++;
            }
        }
        else
        {
            if (day > 30)
            {
                current = day - 30;
                GameManager.Instance.day = 0;
                month++;
            }
        }

        if (month == 13)
        {
            year++;
            month = 1;
        }
        
        GameManager.Instance.year = year;
        GameManager.Instance.month = month;
        GameManager.Instance.hour = hour;

        dateUI.text = ($"{year}year {month}month {day}day {hour}hour");
    }

}
