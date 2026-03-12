using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Meteors;

    float timer = 0f;
    float spawnTime = 2f;

    void Update()
    {
        timer =  timer+Time.deltaTime;

        if (timer >= spawnTime)
        {
            SpawnMeteor();
            timer = 0f;
        }
    }

    void SpawnMeteor()
    {
        float x = Random.Range(-120f, 120f);
        float z = 70f;
        Vector3 pos = new Vector3(x, 0, z);

        int randomIndex = Random.Range(0, Meteors.Length);

        Instantiate(Meteors[randomIndex], pos, Quaternion.identity);
    }
}