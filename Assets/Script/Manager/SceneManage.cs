using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{

    public void MainScene()
    {
        UIManager.Instance.GameOverObj.SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        GameManager.Instance.money = 0f;
        GameManager.Instance.KillCount = 0;
        SceneManager.LoadScene("Main");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage1");
        UIManager.Instance.GameOverObj.SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.KillCountReset(3);
    }

    public void Stage2Scene()
    {
        SceneManager.LoadScene("Stage2");
        UIManager.Instance.GameOverObj.SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.KillCountReset(4);
    }

    public void Stage3Stage()
    {
        SceneManager.LoadScene("Stage3");
        UIManager.Instance.GameOverObj.SetActive(false);
        GameManager.Instance.PlayerHp = GameManager.Instance.PlayerMaxHp;
        Time.timeScale = 1f;
        GameManager.Instance.KillCountReset(5);
    }
}
