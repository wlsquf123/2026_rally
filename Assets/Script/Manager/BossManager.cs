using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject BossObj;

    public bool bossSpawned = false; // 보스 스폰 첨에 안나옴 

    // Update is called once per frame
    void Update()
    {
        if (!bossSpawned && GameManager.Instance.KillCount == GameManager.Instance.targetKillCount)
        {
            bossSpawned = true;
            Instantiate(BossObj);
        }
        if (GameManager.Instance.KillCount > GameManager.Instance.targetKillCount)
        {
            UIManager.Instance.StageClearUI();
        }
    }
}
