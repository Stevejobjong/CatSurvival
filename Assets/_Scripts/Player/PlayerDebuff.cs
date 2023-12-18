using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuff : MonoBehaviour
{
    private bool isWet = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // "Rain" �±״� �� ��ƼŬ�� �Ҵ�Ǿ� �־�� �մϴ�.
        {
            ApplyWetDebuff(); // ���� ����� ����
        }
    }
    void ApplyWetDebuff()
    {
        if (!isWet)
        {
            // ���⿡ ���� ������� �����ϴ� �ڵ带 �ۼ��մϴ�.
            // ���� ���, �̵� �ӵ��� ���ҽ�Ű�ų� Ư�� ����� �����ϴ� ���� �۾��� ������ �� �ֽ��ϴ�.
            // �� ���������� Debug.Log�� �޽����� ����ϴ� ������ ��ü�մϴ�.
            Debug.Log("Player is wet!");

            isWet = true; // �÷��̾� ���¸� �������� ����
            Invoke("RemoveWetDebuff", 5.0f); // 5�� �� ���� ����� ����
        }
    }

    void RemoveWetDebuff()
    {
        isWet = false; // ���� ����� ����
        Debug.Log("Player is dry now!");
        // ���� ������� ���ŵǸ� �÷��̾ �ٽ� ���������� �۵��ϵ��� �����մϴ�.
    }
}
