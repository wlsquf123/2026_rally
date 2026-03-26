using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image PlayerHpImage; // 체력바 이미지
    public Text PlayerHpText; // 체력바 텍스트
    public Text PlayerMoneyText;
    public Text PlayerMoneyTextStore;

    public GameObject Store;
    //public Text QuickSlotText;

    public GameObject GameOverObj;
    public GameObject GameClearObj;

    public Text ScoreText; // 점수 텍스트


    void Update()
    {
        StateManagement();
    }

    public void StateManagement()
    {
        ScoreText.text = "Score: " + GameManager.Instance.CurrentScore.ToString(); // 실시간 점수 갱신
        PlayerHpImage.fillAmount = GameManager.Instance.PlayerHp / GameManager.Instance.PlayerMaxHp;
        PlayerHpText.text = GameManager.Instance.PlayerHp.ToString() + " / " + GameManager.Instance.PlayerMaxHp.ToString();
        PlayerMoneyText.text = GameManager.Instance.money.ToString();
        PlayerMoneyTextStore.text = GameManager.Instance.money.ToString();
    }

    public void GameOverUI()
    {
        GameOverObj.SetActive(true);
    }

    // 스테이지 클리어 UI 활성화
    public void StageClearUI()
    {
        GameClearObj.SetActive(true);
    }
}
