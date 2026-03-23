using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;

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
        timer += Time.deltaTime;

        if (timer <= targetTime)
        {
            transform.LookAt(TargetTransform);
        }
        transform.Translate(0, 0, speed * Time.deltaTime);
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

    /// <summary>
    /// 함수의 매개변수로 들어온 Transform을 추적하도록(LookAt)하도록 변경
    /// 여기에 블랙홀 Transform넣으면 되는거 아님?
    /// </summary>
    /// <param name="enemyTransform"></param>
    public void Homing(Transform enemyTransform)
    {
        // enemyTransform == HomingModule 콜라이더에 닿은 적
        targetTime = 999f;
        TargetTransform = enemyTransform;
    }
}