using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject UIManagerObj;
    public GameObject StoreManagerObj;
    public GameObject MainObj;
    public GameObject Ranking;

    // 핵심: 모든 이동은 이 함수를 거칩니다.
    public void LoadStage(int index)
    {
        GameManager.Instance.Stage = index; // 현재 스테이지 번호 저장
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.UIManager.GameOverObj.SetActive(false);
        GameManager.Instance.UIManager.GameClearObj.SetActive(false);
        GameManager.Instance.UIManager.EscObj.SetActive(false);

        if (index == 0) // 메인씬 이동
        {
            MainObj.SetActive(true);
            UIManagerObj.SetActive(false);
            StoreManagerObj.SetActive(false);

            GameManager.Instance.money = 0f;
            GameManager.Instance.CurrentScore = 0;
            SceneManager.LoadScene("Main");
        }
        else // 스테이지 이동 (Stage1, Stage2, Stage3.)
        {
            MainObj.SetActive(false);
            UIManagerObj.SetActive(true);
            StoreManagerObj.SetActive(true);
            SceneManager.LoadScene("Stage" + index);
        }
    }

    // [게임 오버 시] "다시하기" 버튼에 연결
    public void RetryStage()
    {
        LoadStage(GameManager.Instance.Stage);
        GameManager.Instance.CurrentScore = GameManager.Instance.SaveScore;
    }

    // [게임 클리어 시] "다음 스테이지" 버튼에 연결
    public void NextStage()
    {
        // 현재 스테이지 번호 + 1 로 이동
        LoadStage(GameManager.Instance.Stage + 1);
        GameManager.Instance.SaveScore = GameManager.Instance.CurrentScore;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void EscExit()
    {
        GameManager.Instance.UIManager.EscObj.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Main()
    {
        GameManager.Instance.UIManager.GameOverObj.SetActive(false);
        GameManager.Instance.UIManager.GameClearObj.SetActive(false);
        GameManager.Instance.UIManager.EscObj.SetActive(false);
        UIManagerObj.SetActive(false);
        StoreManagerObj.SetActive(false);
        MainObj.SetActive(true);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void Stage1()
    {
        GameManager.Instance.UIManager.GameOverObj.SetActive(false);
        GameManager.Instance.UIManager.GameClearObj.SetActive(false);
        GameManager.Instance.UIManager.EscObj.SetActive(false);
        UIManagerObj.SetActive(true);
        StoreManagerObj.SetActive(true);
        MainObj.SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        GameManager.Instance.money = 0f;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage1");
    }
}