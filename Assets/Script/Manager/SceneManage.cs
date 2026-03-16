using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void SceneButton(string x)
    {
        SceneManager.LoadScene(x);
    }

    public void StartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void MainScene()
    { 
        GameManager.Instance.Resets();
        SceneManager.LoadScene("Main");
    }
    }
