using UnityEngine;

public class UIKeepRotation : MonoBehaviour
{
    public Vector3 offset; // 부모로부터 떨어질 거리 (인스펙터에서 조절 가능)
    private Quaternion fixedRotation;

    void Start()
    {
        fixedRotation = transform.rotation;

        // 2. 처음 시작할 때 부모와의 거리 차이를 계산해서 저장 (필요 시)
        // 직접 입력하고 싶다면 아래 offset을 주석 처리하고 인스펙터에서 수정하세요.
        offset = transform.position - transform.parent.position;
    }

    void LateUpdate()
    {
        if (transform.parent != null)
        {
            // 부모가 회전해도 위치는 '부모 위치 + 초기 오프셋'으로 고정 (공전 방지)
            transform.position = transform.parent.position + offset;

            // 회전도 처음에 설정한 값으로 고정
            transform.rotation = fixedRotation;
        }
    }
}