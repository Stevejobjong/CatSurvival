using UnityEngine;

public class CameraController : MonoBehaviour
{
    void LateUpdate()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); // "Player" 태그를 가진 오브젝트 찾기

        if (playerObject != null)
        {
            Transform player = playerObject.transform; // 플레이어 오브젝트의 Transform 가져오기

            Vector3 newPosition = player.position; // 플레이어의 현재 위치를 가져옴
            newPosition.y = transform.position.y; // 미니맵 카메라의 높이를 유지

            transform.position = newPosition; // 미니맵 카메라를 플레이어 위치로 이동
            //transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); // 미니맵 카메라가 플레이어를 따라 회전
        }
        else
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
        }
    }
}
