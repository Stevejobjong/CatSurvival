using UnityEngine;

public class CameraController : MonoBehaviour
{
    void LateUpdate()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); // "Player" �±׸� ���� ������Ʈ ã��

        if (playerObject != null)
        {
            Transform player = playerObject.transform; // �÷��̾� ������Ʈ�� Transform ��������

            Vector3 newPosition = player.position; // �÷��̾��� ���� ��ġ�� ������
            newPosition.y = transform.position.y; // �̴ϸ� ī�޶��� ���̸� ����

            transform.position = newPosition; // �̴ϸ� ī�޶� �÷��̾� ��ġ�� �̵�
            //transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); // �̴ϸ� ī�޶� �÷��̾ ���� ȸ��
        }
        else
        {
            Debug.LogError("�÷��̾ ã�� �� �����ϴ�.");
        }
    }
}
