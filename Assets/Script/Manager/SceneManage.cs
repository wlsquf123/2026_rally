using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void MainScene()
    {
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.money = 0f;
        GameManager.Instance.KillCount = 0;
        SceneManager.LoadScene("Main");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        GameManager.Instance.KillCountReset(3);
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2Scene()
    {
        UIManager.Instance.GameOverObj.SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.KillCountReset(4);
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3Stage()
    {
        UIManager.Instance.GameOverObj.SetActive(false);
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
