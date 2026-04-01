using UnityEngine;

public class Meteor : MonoBehaviour
{
    float Speed;
    float rotSpeed;
    Vector3 dir;

    void Start()
    {
        Speed = Random.Range(3f, 8f);
        rotSpeed = Random.Range(-200f, 200f);
        float randomX = Random.Range(-0.5f, 0.5f);
        float randomZ = Random.Range(-1f, -0.2f);

        dir = new Vector3(randomX, 0, randomZ).normalized;

    }

    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime, Space.World);
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerHp -= 10;
            GameManager.Instance.AddScore(-10); // 미사일 피격 시 100점 감점
            Destroy(gameObject);
        }
        if (other.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Damage(1f);
            Destroy(gameObject);
        }
        if (other.CompareTag("God"))
        {
            Destroy(gameObject);
        }
    }
}