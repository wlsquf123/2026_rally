using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] Items; // 아이템 프리팹들

    float timer = 0f;
    float itemSpawnTime = 20f; // 아이템 생성 주기

    void Update()
    {
        // GameManager의 현재 스테이지 번호를 체크
        int currentStage = GameManager.Instance.Stage;

        // 예: 스테이지 1은 아이템이 자주 나오고, 스테이지가 올라갈수록 귀해짐
        // 혹은 특정 로직에 따라 스폰 중지 가능
        timer += Time.deltaTime;

        if (timer >= itemSpawnTime)
        {
            SpawnItem();
            timer = 0f;
        }
    }

    void SpawnItem()
    {
        if (Items.Length == 0) return;

        float x = Random.Range(-120f, 120f);
        float z = 70f;
        Vector3 pos = new Vector3(x, 0, z);

        int randomIndex = Random.Range(0, Items.Length);
        Instantiate(Items[randomIndex], pos, Quaternion.identity);
    }
}