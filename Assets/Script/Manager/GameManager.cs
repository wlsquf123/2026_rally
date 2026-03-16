using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float PlayerMaxHp = 100f; // 플레이어 최대체력
    public float PlayerHp; // 플레이어 체력
    public float money = 0f; // 플레이어 머뉘


    private void Awake()
    {
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
        GAMEOVER();
    }

    public void GAMEOVER()
    {
        if (PlayerHp <= 0)
        {
            UIManager.Instance.GAMEOVERUI();
            Time.timeScale = 0f;
        }
    }

    public void PlayerMoney(float m)
    {
        money += m;
    }

    public void Resets()
    {
        PlayerHp = PlayerMaxHp;
        money = 0f;
        UIManager.Instance.GameOverObj.SetActive(false);
        

    }
}
