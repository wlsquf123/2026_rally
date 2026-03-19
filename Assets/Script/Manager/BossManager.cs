using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject BossObj;

    public bool bossSpawned = false;

    // Update is called once per frame
    void Update()
    {
        if (!bossSpawned && GameManager.Instance.KillCount == GameManager.Instance.targetKillCount)
        {
            SpawnBoss();
        }
        if (GameManager.Instance.KillCount > GameManager.Instance.targetKillCount)
        {
            UIManager.Instance.StageClearUI();
        }
    }
    void SpawnBoss()
    {
        bossSpawned = true;
        Instantiate(BossObj);
    }
}
