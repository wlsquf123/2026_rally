using System.IO;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 게임매니저
    public UIManager UIManager;
    public StoreManager StoreManager;
    public SceneManage SceneManage;
    public RankingManager RankingManager;

    public float PlayerMaxHp = 100f; // 플레이어 최대체력
    public float PlayerHp; // 플레이어 체력
    public float money = 0f; // 플레이어 머뉘

    public int Stage = 1; // 기본값

    public bool oneMoneyAdd = false; // 돈 추가 (일회성)
    public bool oneKille = false; // 강제 적 사망 (일회성)

    public bool HomingModule; // 강제 유도
    public bool TimeStopper; // 시간 정지
    public bool Reflector; // 공격 반사
    public bool BlackHole; // 블랙홀
    public bool SlowField; // 감속장

    public GameObject BlackHolePrefeb; // 블랙홀 프리팹

    public int CurrentScore = 0; // 현재 점수
    public string PlayerName = "Player1"; // 랭킹 입력용

    private string savePath;
    private string rankPath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "save.json");
        rankPath = Path.Combine(Application.persistentDataPath, "rank.json");
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



    public void AddScore(int amount)
    {
        CurrentScore = Mathf.Max(0, CurrentScore + amount);
    }

    // [요구사항 15] 세이브 기능
    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.money = money;
        data.stage = Stage;
        data.playerHp = PlayerHp;

        foreach (var part in StoreManager.Parts)
        {
            data.partStates.Add(new PartSaveInfo { type = part.ThisPartType, state = part.ThisPartState });
        }
        // 퀵슬롯 정보는 StoreManager 등에서 가져와 저장 가능

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    // [요구사항 12] 랭킹 업데이트 (내림차순 정렬)
    public void UpdateRanking(string name, int score)
    {
        RankList list = LoadRanking();
        list.ranks.Add(new RankData { name = name, score = score });
        // 점수 높은 순으로 정렬 후 상위 5명만 남김
        list.ranks = list.ranks.OrderByDescending(x => x.score).Take(5).ToList();

        string json = JsonUtility.ToJson(list);
        File.WriteAllText(rankPath, json);
    }

    public RankList LoadRanking()
    {
        if (File.Exists(rankPath))
        {
            string json = File.ReadAllText(rankPath);
            return JsonUtility.FromJson<RankList>(json);
        }
        return new RankList();
    }
}
