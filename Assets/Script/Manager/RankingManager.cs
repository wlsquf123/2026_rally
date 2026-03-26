using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    [Header("Ranking Data")]
    private string rankPath;
    private RankList rankList = new RankList();

    [Header("UI References")]
    public GameObject RankingPanel;   // 랭킹 창 전체 부모
    public InputField NameInput;      // 이름 입력창
    public Text[] RankSlotTexts;      // 1~5위 표시 텍스트 (배열 크기 5)

    void Awake()
    {
        // 1. 경로 설정
        rankPath = Path.Combine(Application.persistentDataPath, "rank.json");

        // 2. 기존 데이터 로드
        LoadRanking();
    }

    // 1. 랭킹 데이터 로드
    public void LoadRanking()
    {
        if (File.Exists(rankPath))
        {
            string json = File.ReadAllText(rankPath);
            rankList = JsonUtility.FromJson<RankList>(json);

            if (rankList == null || rankList.ranks == null)
            {
                rankList = new RankList { ranks = new List<RankData>() };
            }
        }
        else
        {
            rankList = new RankList { ranks = new List<RankData>() };
        }
    }

    // 2. 랭킹 UI 열기 (게임 종료 시 호출)
    public void OpenRankingPanel()
    {
        // UI 활성화 (GameManager 연결 방식 유지)
        if (GameManager.Instance.SceneManage.Ranking != null)
            GameManager.Instance.SceneManage.Ranking.SetActive(true);

        UpdateRankDisplay();
    }

    // 3. 새로운 랭킹 등록 (인스펙터의 Button -> OnClick에 연결)
    public void AddNewRank()
    {
        string pName = string.IsNullOrEmpty(NameInput.text) ? "Unknown" : NameInput.text;
        int pScore = GameManager.Instance.CurrentScore;

        // 데이터 추가 및 정렬
        rankList.ranks.Add(new RankData { name = pName, score = pScore });
        rankList.ranks = rankList.ranks.OrderByDescending(x => x.score).Take(5).ToList();

        // 파일 저장
        string json = JsonUtility.ToJson(rankList);
        File.WriteAllText(rankPath, json);

        // UI 갱신
        UpdateRankDisplay();

        Debug.Log("랭킹 저장 성공!");
    }

    // 4. UI 텍스트 갱신
    public void UpdateRankDisplay()
    {
        if (rankList == null || rankList.ranks == null) return;

        for (int i = 0; i < RankSlotTexts.Length; i++)
        {
            if (RankSlotTexts[i] == null) continue;

            if (i < rankList.ranks.Count)
            {
                RankSlotTexts[i].text = string.Format("{0}. {1} - {2}pts",
                    i + 1, rankList.ranks[i].name, rankList.ranks[i].score);
            }
            else
            {
                RankSlotTexts[i].text = (i + 1) + "null";
            }
        }
    }
}