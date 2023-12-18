using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Season;

public class Season : MonoBehaviour
{
    //계절에 따른 온도 변화만 구현
    public float LowTemperature = -5.0f; //1월
    public float HighTemperature = 30.0f; //7월

    private float[] monthlyTemperatures = new float[12]; // 12개월 온도를 저장할 배열

    public void SeasonalChanges() //계절변화에 따른 온도 변화
    {
        float temperatureDifference = HighTemperature - LowTemperature;
        float increment = temperatureDifference / 6.0f; // 6개월에 걸쳐 증가되는 값을 계산

        // 1월부터 7월까지의 온도 설정
        for (int i = 0; i <= 6; i++)
        {
            monthlyTemperatures[i] = LowTemperature + (increment * i);
        }

        // 8월부터 12월까지의 온도 설정 (7월 온도에서 감소하도록 설정)
        for (int i = 7; i < 12; i++)
        {
            monthlyTemperatures[i] = HighTemperature - (increment * (i - 6));
        }
    }

    public float GetTemperatureForMonth(int month)
    {
        if (month >= 1 && month <= 12)
        {
            return monthlyTemperatures[month - 1];
        }
        else
        {
            return 0.0f;
        }
    }

}
