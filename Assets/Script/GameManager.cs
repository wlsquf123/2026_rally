using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float PlayerMaxHp = 100f; // 플레이어 최대체력
    public float PlayerHp; // 플레이어 체력

    public float[] enemysHp;
    float[] enemysMaxHp;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
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

    // Update is called once per frame
    void Update()
    {
        GAMEOVER();
    }

    public void GAMEOVER()
    {
        if (PlayerHp <= 0)
        {
            Time.timeScale = 0f;
        }
    }

    public void EnemyHp()
    {
        enemysHp[0] = enemysMaxHp[0];
    }
}
