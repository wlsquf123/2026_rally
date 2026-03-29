using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum missileType
{
    Null,
    Bomber
}

public class Missile : MonoBehaviour
{
    public float speed;
    float spin = 50f;
    public missileType type;

    public Transform TargetTransform;
    public GameObject explosionPrefab;
    bool isHit = false;

    float timer;
    public float targetTime;

    public float orspeed = 0f;

    public bool IsCoroutineRunnin = false;

    private void Awake()
    {
        IsCoroutineRunnin = false;
    }

    void Start()
    {
        TargetTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Move();
        timer += Time.deltaTime;

        if (timer <= targetTime)
        {
            transform.LookAt(TargetTransform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isHit) return;
        Enemy enemy = other.GetComponent<Enemy>();

        if (other.CompareTag("Player") || other.CompareTag("Meteor") || other.CompareTag("Enemy") || other.CompareTag("God"))
        {
            isHit = true;

            // 폭발 이펙트 추가
            GameObject eff = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(eff, 3.0f);

            if (other.CompareTag("Player"))
            {
                isHit = true;
                GameManager.Instance.PlayerHp -= 5;
                GameManager.Instance.AddScore(-100); // 미사일 피격 시 100점 감점
                Destroy(gameObject);
            }

            if (other.CompareTag("Enemy"))
            {
                enemy.Damage(5f);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }

    void Move()
    {
        switch (type)
        {
            case missileType.Bomber:
                transform.Rotate(0, spin * Time.deltaTime, 0);
                break;
        }

        // 2. 공통 이동: 모든 미사일은 바라보는 방향(Forward)으로 전진
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public IEnumerator StopAndResume(float delay)
    {
        IsCoroutineRunnin = true;

        orspeed = speed; // 현재 속도 저장
        speed = 0f; // 속도 정지

        yield return new WaitForSeconds(delay); // 3초 대기

        speed = orspeed; // 속도 복구
        IsCoroutineRunnin = false;
    }

    public IEnumerator SlowAndResume(float delay)
    {
        IsCoroutineRunnin = true;

        orspeed = speed; // 현재 속도 저장
        speed = 3f;            // 속도 슬로우

        yield return new WaitForSeconds(delay); // 3초 대기

        speed = orspeed; // 속도 복구
        IsCoroutineRunnin = false;
    }

    public void Homing(Transform enemyTransform)
    {
        // enemyTransform == HomingModule 콜라이더에 닿은 적
        targetTime = 999f;
        TargetTransform = enemyTransform;
    }
}