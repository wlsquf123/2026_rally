using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using Unity.VisualScripting;

public class RankingManager : MonoBehaviour
{
    [Header("Ranking Data")]
    // 0번째가 1등, 4번째가 5등
    private RankData[] RankDataArr = new RankData[5];

    [Header("UI References")]
    public GameObject RankingPanel;   // 랭킹 창 전체 부모
    public InputField NameInput;      // 이름 입력창
    public Text[] RankSlotTexts;      // 1~5위 표시 텍스트 (배열 크기 5)

    void Awake()
    {
        // 2. 기존 데이터 로드
        LoadRanking();
        for (int i = 0; i < RankDataArr.Length; i++)
            RankDataArr[i] = new();
    }

    // 1. 랭킹 데이터 로드
    public void LoadRanking()
    {
       
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
        string pName = NameInput.text;
        int pScore = GameManager.Instance.CurrentScore;

        // RankDataArr 안에는 빈 데이터(0점, AAA가 들어간 데이터)만 있어.
        // 1. 수정하거나 / 2. 새로 만들어서 넣던가
        // 일단 지금 pName pScore로 지금 플레이 하는 사람이 누군지 알기 때문에
        // 반복문을 통해서 배열을 읽을 거고, 거기에 있는 스코어 중에 재낄 수 있는 사람이 있으면 밀어내고 들어간다.

        // 우선 복사합니다.
        var TempRankDataArr = new RankData[5];
        for (int i = 0; i < 5; i++)
        {
            // new는 Class 틀을 사용해서 실제로 데이터를 찍어 내는 함수. (GameObject의 Instanciate 생성같은 느낌. 데이터 상에서 찍어낼 뿐)
            TempRankDataArr[i] = new();
            TempRankDataArr[i].Savedname = RankDataArr[i].Savedname;
            TempRankDataArr[i].Savedscore = RankDataArr[i].Savedscore;
        }

        // 여기서부터는 원본 데이터 활용
        // 배열의 0번째 = 1등, 1번째 = 2등.... 4번째 = 5등

        // 임시용 내가 들어갈 자리 표기용
        int pIndex = 99999;
        for (int i = 0; i < 5; i++)
        {
            // 1명이라도 재꼈으면?
            if (pScore >= RankDataArr[i].Savedscore)
            {
                // 재낀 등수 표기하고 
                pIndex = i;

                // 1번 재끼면 바로 반복문 강제 탈출
                break;
            }
        }

        // 뭔가 재꼈음. 99999가 아님.
        if (pIndex != 99999)
        {
            // 일단 해당 자리에 내가 들어감.
            TempRankDataArr[pIndex].Savedscore = pScore;
            TempRankDataArr[pIndex].Savedname = pName;

            // 내가 5등으로 랭킹에 올랐으면?
            if (pIndex == 4)
            {
                // 그냥 임시로 저장하고 수정했던 TempRankDataArr 데이터 불러와서 덮어쓰고 끝
                for (int i = 0; i < 5; i++)
                {
                    RankDataArr[i].Savedname = TempRankDataArr[i].Savedname;
                    RankDataArr[i].Savedscore = TempRankDataArr[i].Savedscore;
                }
                return;
            }

            // 나보다 한 수 뒤에 있는 사람들부터 접근.
            for (int i = pIndex + 1; i < 5; i++)
            {
                // 원본 데이터의 값을 가져와서 내 뒤부터 배열의 끝까지 덮어쓴다.
                TempRankDataArr[i].Savedscore = RankDataArr[i - 1].Savedscore;
                TempRankDataArr[i].Savedname = RankDataArr[i - 1].Savedname;
            }

            // 덮어쓰기
            for (int i = 0; i < 5; i++)
            {
                RankDataArr[i].Savedname = TempRankDataArr[i].Savedname;
                RankDataArr[i].Savedscore = TempRankDataArr[i].Savedscore;
            }
        }

        // 1등부터 AAA. BBB, CCC, DDD, EEE
        // QQQ라는 애가 AAA와 BBB 사이 점수를 획득하면?

        // AAA, BBB, CCC, DDD, EEE 이게 원본 데이터

        // AAA, QQQ, CCC, DDD, EEE 이게 임시 데이터의 현재 상태

        // AAA, QQQ, BBB, CCC, DDD 임시 데이터가 이렇게 바뀌어야 함

        // UI 갱신
        UpdateRankDisplay();
    }

    // 4. UI 텍스트 갱신
    public void UpdateRankDisplay()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(RankSlotTexts[i]);
            Debug.Log(RankDataArr[i].Savedname);
            RankSlotTexts[i].text = RankDataArr[i].Savedname + " / " + RankDataArr[i].Savedscore + "점";
        }
    }
}