using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject[] Meteors;
    float timer = 0f;
    public float spawnTime = 2f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            float x = Random.Range(-120f, 120f);
            float z = 70f;
            Vector3 pos = new Vector3(x, 0, z);

            int randomIndex = Random.Range(0, Meteors.Length);

            Instantiate(Meteors[randomIndex], pos, Quaternion.identity);
            timer = 0f;
        }
    }
}