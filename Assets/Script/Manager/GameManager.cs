using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float PlayerMaxHp = 100f; // 플레이어 최대체력
    public float PlayerHp; // 플레이어 체력
    public float money = 0f; // 플레이어 머뉘

    public int KillCount = 0;
    public int targetKillCount = 3; // 기본값

    public bool Hit = false;

    public bool HomingModule; // 강제 유도
    public bool TimeStopper; // 시간 정지
    public bool Reflector; // 공격 반사
    public bool BlackHole; // 블랙홀
    public bool SlowField; // 감속장

    public GameObject BlackHolePrefeb;

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
        GAMEOVER(); // 게임오버
        CheatKey(); // 치트키

        // 강제 유도
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MovePlayer player = GameObject.FindObjectOfType<MovePlayer>();
            player.EnableHomingModule();
        }

        // 시간 정지
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Missile[] allMissiles = GameObject.FindObjectsOfType<Missile>();
            foreach (Missile mis in allMissiles)
            {
                if (!mis.IsCoroutineRunnin)
                {
                    StartCoroutine(mis.StopAndResume(3.0f));
                }
            }
        }

        // 블랙홀
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(BlackHolePrefeb); // 생성
        }

        // 감속장
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            float slowRange = 50f; // 감지 반경
            Missile[] allMissiles = GameObject.FindObjectsOfType<Missile>();
            GameObject playerObj = GameObject.FindWithTag("Player");

            // 플레이어의 위치값
            UnityEngine.Vector3 playerPos = playerObj.transform.position;

            foreach (Missile mis in allMissiles)
            {
                // 플레이어와 각 미사일 사이의 거리를 계산
                float distance = UnityEngine.Vector3.Distance(playerPos, mis.transform.position);

                if (distance <= slowRange) // 범위 안에 있다면
                {
                    if (!mis.IsCoroutineRunnin)
                        StartCoroutine(mis.SlowAndResume(3.0f));
                }
            }
        }
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
        KillCount = 0;
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

        if (Input.GetKeyDown(KeyCode.F4) && !Hit)
        {
            // 돈 추가
            money += 10000;
            Hit = true;
        }

    }
}
