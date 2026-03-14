using UnityEngine;
using UnityEngine.UI;

public enum EnemyType
{
    Null = 0,
    Scout,
    Fighter,
    HeavyCruiser,
    Interceptor,  
    Bomber,
    Boss1
}

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public Image hpBar;
    public GameObject[] missilePrefab;
    Transform player;

    public float speed;
    public float rotSpeed;
    public float attackTime;
    public float hp;
    public float maxHp;

    float timer = 0f;
    float timer1 = 0f;
    float timer2 = 0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        hp = maxHp;
    }

    void Update()
    {
        Vector3 dir = player.position - transform.position;
        Quaternion target = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, rotSpeed * Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);

        timer += Time.deltaTime;
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        Attack();
    }

    void Attack()
    {
        // ±âº» Àû
        switch (type)
        {
            case EnemyType.Scout:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0f;
                }
                break;

            case EnemyType.Fighter:
                if (timer1 >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 10, transform.rotation);
                    timer1 = 0f;
                }
                if (timer >= attackTime * 1.1f)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0f;
                }
                if (timer2 >= attackTime * 1.2f)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0f;
                    timer2 = 0f;
                    timer1 = 0f;
                }
                break;

            case EnemyType.HeavyCruiser:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0f;
                }
                break;

            case EnemyType.Interceptor:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 5, transform.rotation);
                    timer = 0f;
                }
                break;

            case EnemyType.Bomber:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 5, transform.rotation);
                    timer = 0f;
                }        
                break;

            case EnemyType.Boss1:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0f;
                }
                if (timer1 >= attackTime * 1.1f)
                {
                    Instantiate(missilePrefab[1], transform.position + transform.forward * 10, transform.rotation);
                    timer1 = 0f;
                }
                if (timer2 >= attackTime * 1.2f)
                {
                    Instantiate(missilePrefab[2], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0f;
                    timer2 = 0f;
                    timer1 = 0f;
                }
                break;

        }
    }

    public void Damage(float x)
    {
        hp -= x;
        hpBar.fillAmount = hp / maxHp;

        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
}