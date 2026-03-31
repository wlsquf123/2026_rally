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
    Boss1,
    Boss2,
    Boss3
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
    public float Reward;
    public int Score;

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

    
    void Attack() // 적 미사일 생성
    {
        switch (type)
        {
            // 정찰기
            case EnemyType.Scout:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0;
                }
                break;

            // 전투기
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

            // 중장갑함
            case EnemyType.HeavyCruiser:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0f;
                }
                break;

            // 요격기
            case EnemyType.Interceptor:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 5, transform.rotation);
                    timer = 0f;
                }
                break;

            // 폭격기
            case EnemyType.Bomber:
                if (timer >= attackTime)
                {
                    Instantiate(missilePrefab[0], transform.position + transform.forward * 20, transform.rotation);
                    timer = 0f;
                }
                break;
            // 보스
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
                    timer = 0f;
                }
                if (timer2 >= attackTime * 1.2f)
                {
                    Instantiate(missilePrefab[2], transform.position + transform.forward * 10, transform.rotation);
                    timer = 0f;
                    timer1 = 0f;
                    timer2 = 0f;
                }
                break;

        }
    }

    public void Damage(float x)
    {
        hp -= x;
        hpBar.fillAmount = hp / maxHp;

        if (hp <= 0)
        {
            if (type == EnemyType.Boss1 || type ==  EnemyType.Boss2 || type == EnemyType.Boss3)
            {
                GameManager.Instance.UIManager.GameClearObj.SetActive(true);
                if (GameManager.Instance.Stage == 3)
                {
                    GameManager.Instance.RankingManager.OpenRankingPanel();
                }
                Time.timeScale = 0f;

            }
            Destroy(gameObject);
            GameManager.Instance.PlayerMoney(Reward);
            GameManager.Instance.AddScore(Score);
        }
    }
}