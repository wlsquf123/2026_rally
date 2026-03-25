using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 게임매니저
    public UIManager UIManager;
    public StoreManager StoreManager;
    public SceneManage SceneManage;

    public float PlayerMaxHp = 100f; // 플레이어 최대체력
    public float PlayerHp; // 플레이어 체력
    public float money = 0f; // 플레이어 머뉘

    public int KillCount = 0; // 킬 카운트
    public int targetKillCount = 3; // 타겟 킬 시작 기본값

    public bool oneMoneyAdd = false; // 돈 추가 (일회성)
    public bool oneKille = false; // 강제 적 사망 (일회성)

    public bool HomingModule; // 강제 유도
    public bool TimeStopper; // 시간 정지
    public bool Reflector; // 공격 반사
    public bool BlackHole; // 블랙홀
    public bool SlowField; // 감속장

    public GameObject BlackHolePrefeb; // 블랙홀 프리팹

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

        // 폭탄은 파츠 아님
        if (Input.GetKeyDown(KeyCode.P))
        {
            Missile[] allMissile = GameObject.FindObjectsOfType<Missile>();
            foreach (Missile mis in allMissile)
            {
                Destroy(mis.gameObject);
            }
        }

        // 강제 유도 (파츠임)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
                MovePlayer player = GameObject.FindObjectOfType<MovePlayer>();
                player.EnableHomingModule();
        }

        // 시간 정지 (파츠임)
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

        // 공격 반사 (파츠임)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
                var player = GameObject.FindObjectOfType<MovePlayer>();
                player.EnableParrying();
        }

        // 블랙홀 (파츠임)
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
                Instantiate(BlackHolePrefeb); // 생성
        }

        // 감속장 (파츠임)
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
            GameManager.Instance.UIManager.GameOverUI();
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
        // 디버그 모드 (온오프)
        if (Input.GetKeyDown(KeyCode.F1))
        {

        }

        // 무적 (온오프)
        if (Input.GetKeyDown(KeyCode.F2))
        {
            MovePlayer player = GameObject.FindObjectOfType<MovePlayer>();
            player.GodModeToggle();
        }

        // 강제 적 사망 (일회성)
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Enemy[] enemy = GameObject.FindObjectsOfType<Enemy>();
            foreach (Enemy en in enemy)
            {
                en.Damage(999f);
                oneKille = true;
            }
        }

        // 돈 추가 (일회성)
        if (Input.GetKeyDown(KeyCode.F4) && !oneMoneyAdd)
        {
            money += 10000;
            oneMoneyAdd = true;
        }
    }
}
