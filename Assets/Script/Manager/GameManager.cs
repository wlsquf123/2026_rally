using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float PlayerMaxHp = 100f; // 플레이어 최대체력
    public float PlayerHp; // 플레이어 체력
    public float money = 0f; // 플레이어 머뉘

    public int KillCount = 0;
    public int targetKillCount = 3; // 기본값
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayerHp = PlayerMaxHp;
    }
    void Update()
    {
        GAMEOVER();
        CheatKey();
    }

    public void GAMEOVER()
    {
        if (PlayerHp <= 0)
        {
            UIManager.Instance.GAMEOVERUI();
            Time.timeScale = 0f;
        }
    }

    public void PlayerMoney(float m)
    {
        money += m;
    }

    public void KillCountReset(int count) // 스테이지가 시작될 때 호출해서 목표치를 설정할 함수
    {
        targetKillCount = count;
        KillCount = 0; // 카운트 초기화는 덤!
    }

    public void CheatKey()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // 디버그모드
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            // 무적
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            // 돈 추가
            money += 10;
        }
        
    }
}
