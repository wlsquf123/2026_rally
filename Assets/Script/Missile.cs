using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;

    Transform player;
    bool isHit = false;

    float timer;
    public float targetTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= targetTime)
        {
            transform.LookAt(player);
        }
        transform.Translate(0, 0, speed * Time.deltaTime);
        //transform.Rotate(90, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isHit) return;
        Enemy enemy = other.GetComponent<Enemy>();

        if (other.CompareTag("Player"))
        {
            isHit = true;
            GameManager.Instance.PlayerHp -= 5;
            Destroy(gameObject);
        }

        if (other.CompareTag("Meteor"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            enemy.Damage(5f);
            Destroy(gameObject);
        }
    }
}