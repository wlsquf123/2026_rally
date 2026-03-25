using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject BossObj;

    public bool bossSpawned = false; // 보스 스폰 첨에 안나옴 
    private bool isClear = false;

    // Update is called once per frame
    void Update()
    {
        if (!bossSpawned && GameManager.Instance.KillCount == GameManager.Instance.targetKillCount)
        {
            bossSpawned = true;
            Instantiate(BossObj);
        }
        if (!isClear && GameManager.Instance.KillCount > GameManager.Instance.targetKillCount)
        {
            isClear = true;
            GameManager.Instance.UIManager.StageClearUI();
            Time.timeScale = 0f;
        }
    }
}
