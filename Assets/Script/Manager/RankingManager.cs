using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RankData
{
    public int Score = 0;
    public string Name = "AAA";
}

public class RankingManager : MonoBehaviour
{
    public RankData[] rankDatas = null;
    public RankData[] NewRankDatas = null;
    public Text[] RankText;

    public InputField InputName;

    void Awake()
    {
        rankDatas = new RankData[5];
        NewRankDatas = new RankData[5];
        for (int i = 0; i < 5; i++)
        {
            rankDatas[i] = new RankData();
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
        int newScore = GameManager.Instance.CurrentScore;
        string newName = InputName.text;

        RankData originalData = new RankData();
        int index = 0;
        bool isChanged = false;

        for (int i = 0; i < 5; i++)
        {
            if (rankDatas[i].Score < newScore)
            {
                index = i;
                originalData.Score = rankDatas[i].Score;
                originalData.Name = rankDatas[i].Name;
                isChanged = true;
                rankDatas[i].Score = newScore;
                rankDatas[i].Name = newName;
                break;
            }
        }

        if (!isChanged)
            return;

        for (int i = 4; i > index + 1; i--)
        {
            rankDatas[i].Score = rankDatas[i - 1].Score;
            rankDatas[i].Name = rankDatas[i - 1].Name;
        }
        if ( index == 4)
        {
            return;
        }
        rankDatas[index + 1].Score = originalData.Score;
        rankDatas[index + 1].Name = originalData.Name;

        UpdateRankDisplay();
    }

    // 4. UI 텍스트 갱신
    public void UpdateRankDisplay()
    {
        for(int i = 0; i < rankDatas.Length; i++)
        {
            RankText[i].text = rankDatas[i].Name + " / " + rankDatas[i].Score + "점";
        }
    }
}