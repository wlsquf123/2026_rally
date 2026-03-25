using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject UIManagerObj;
    public GameObject StoreManagerObj;

    public GameObject MainObj;

    private void Awake()
    {
        
    }
    public void MainScene() // 메인 씬~
    {
        MainObj.SetActive(true);
        UIManagerObj.SetActive(false);
        StoreManagerObj.SetActive(false);
        GameManager.Instance.UIManager.GameOverObj[0].SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.money = 0f;
        GameManager.Instance.KillCount = 0;
        SceneManager.LoadScene("Main");
    }

    public void Stage1Scene() // 스테이지1 시작~
    {
        MainObj.SetActive(false);
        UIManagerObj.SetActive(true);
        StoreManagerObj.SetActive(true);
        GameManager.Instance.UIManager.GameOverObj[0].SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        GameManager.Instance.KillCountReset(3);
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2Scene() // 스테이지2 시작~
    {
        GameManager.Instance.UIManager.GameOverObj[0].SetActive(false);
        GameManager.Instance.UIManager.StageClearObj[0].SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.KillCountReset(4);
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3Stage()
    {
        GameManager.Instance.UIManager.GameOverObj[0].SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.KillCountReset(5);
        SceneManager.LoadScene("Stage3");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
