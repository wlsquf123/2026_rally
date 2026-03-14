using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    float Speed;
    float rotSpeed;
    Vector3 dir;
    bool isHit = false;
    void Start()
    {
        Speed = Random.Range(3f, 8f);
        float randomX = Random.Range(-0.5f, 0.5f);
        float randomZ = Random.Range(-1f, -0.2f);

        dir = new Vector3(randomX, 0, randomZ).normalized;

        rotSpeed = Random.Range(-200f, 200f);
    }

    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime, Space.World);
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);


        if (transform.position.x > 130f || transform.position.x < -130f || transform.position.z > 80f || transform.position.z < -80f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (isHit) return;

        if (other.CompareTag("Player"))
        {
            isHit = true;
            GameManager.Instance.PlayerHp -= 10;
            Destroy(gameObject);
        }
        /*if (other.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }*/
        if (other.CompareTag("Enemy"))
        {
            enemy.Damage(1f);
            Destroy(gameObject);
        }
    }
}