using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    Transform Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        // 방금 막 게임매니저에서 소환됨.
        // 1. 플레이어 위치로 텔레포트
        // 2. 블랙홀을 N초 뒤에 삭제

        transform.position = Player.transform.position;
        // N초 뒤에 삭제(변수 파세요~)

        StartCoroutine(BlackHoleDelay(3f));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            Destroy(other.gameObject);
        }
    }

    public IEnumerator BlackHoleDelay (float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    
}
