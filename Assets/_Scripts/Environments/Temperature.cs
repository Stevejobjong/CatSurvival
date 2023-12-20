using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    public TMP_Text temperatureUI;

    public float temperatureDifference = 10.0f;

    private void Update()
    {
        _Temperature();
    }

    public void _Temperature()
    {
        int hour = GameManager.Instance.hour;
        float Temperature = 0;
        float minHour = 2f; // �µ��� ������ ���� �ð�
        float maxHour = 14f; // �µ��� �ְ��� ���� �ð�

        if (hour < maxHour && hour >= minHour)
        {
            Temperature = GameManager.Instance.WorldTemperature + (temperatureDifference/2 * (1 - ((maxHour - hour) / 6)));
        }
        else if (hour >= maxHour)
        {
            Temperature = GameManager.Instance.WorldTemperature + (temperatureDifference/2 * (1 - ((hour - maxHour) / 6)));
        }
        else if (hour < minHour)
        {
            Temperature = GameManager.Instance.WorldTemperature + (temperatureDifference/2 * (1 - ((24-maxHour + hour) / 6)));
        }

        GameManager.Instance.CurrentTemperature = Temperature + GameManager.Instance.IncreaseTemperature;
        temperatureUI.text = GameManager.Instance.CurrentTemperature.ToString("N1") + "��C";
    }
}
