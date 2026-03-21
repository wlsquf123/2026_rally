using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    public float DestroyDelay = 3f;
    Transform Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        // 방금 막 게임매니저에서 소환됨.
        // 1. 플레이어 위치로 텔레포트
        // 2. 블랙홀을 N초 뒤에 삭제

        transform.position = Player.transform.position;
        // N초 뒤에 삭제(변수 파세요~)

        StartCoroutine(BlackHoleDelay(DestroyDelay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            Destroy(other.gameObject);
        }
    }

    // int형인 것을 반환한다는 뜻.
    public int intFunc()
    {
        return 1;
    }

    // void == 없는 것을 반환한다는 뜻.(return이 없더라도 OK)
    public void voidFunc()
    {
        // void == 진짜 없는 거
        // null == 타입(형)은 유지하되, 내부가 비어 있음
        // 진짜 값 넣기
    }

    // N초 뒤에 지워지면 끝~
    public IEnumerator BlackHoleDelay (float delay)
    {
        yield return new WaitForSeconds(delay); // 3초 대기
        Destroy(gameObject);
    }
    
}
