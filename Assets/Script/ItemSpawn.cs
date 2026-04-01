using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] Items; // 아이템 프리팹들

    float timer = 0f;
    float itemSpawnTime = 20f; // 아이템 생성 주기

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= itemSpawnTime)
        {
            float x = Random.Range(-120f, 120f);
            float z = 70f;
            Vector3 pos = new Vector3(x, 0, z);

            int randomIndex = Random.Range(0, Items.Length);
            Instantiate(Items[randomIndex], pos, Quaternion.identity);

            timer = 0f;
        }
    }
}