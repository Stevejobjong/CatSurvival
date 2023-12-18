using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuff : MonoBehaviour
{
    private bool isWet = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // "Rain" 태그는 비 파티클에 할당되어 있어야 합니다.
        {
            ApplyWetDebuff(); // 젖음 디버프 적용
        }
    }
    void ApplyWetDebuff()
    {
        if (!isWet)
        {
            // 여기에 젖음 디버프를 적용하는 코드를 작성합니다.
            // 예를 들어, 이동 속도를 감소시키거나 특정 기능을 제한하는 등의 작업을 수행할 수 있습니다.
            // 이 예제에서는 Debug.Log로 메시지를 출력하는 것으로 대체합니다.
            Debug.Log("Player is wet!");

            isWet = true; // 플레이어 상태를 젖음으로 변경
            Invoke("RemoveWetDebuff", 5.0f); // 5초 후 젖음 디버프 제거
        }
    }

    void RemoveWetDebuff()
    {
        isWet = false; // 젖음 디버프 해제
        Debug.Log("Player is dry now!");
        // 젖음 디버프가 제거되면 플레이어가 다시 정상적으로 작동하도록 설정합니다.
    }
}
