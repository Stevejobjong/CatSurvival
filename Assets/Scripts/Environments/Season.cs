using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Season;

public class Season : MonoBehaviour
{
    //������ ���� �µ� ��ȭ�� ����
    public float LowTemperature = -5.0f; //1��
    public float HighTemperature = 30.0f; //7��

    private float[] monthlyTemperatures = new float[12]; // 12���� �µ��� ������ �迭

    public void SeasonalChanges() //������ȭ�� ���� �µ� ��ȭ
    {
        float temperatureDifference = HighTemperature - LowTemperature;
        float increment = temperatureDifference / 6.0f; // 6������ ���� �����Ǵ� ���� ���

        // 1������ 7�������� �µ� ����
        for (int i = 0; i <= 6; i++)
        {
            monthlyTemperatures[i] = LowTemperature + (increment * i);
        }

        // 8������ 12�������� �µ� ���� (7�� �µ����� �����ϵ��� ����)
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
