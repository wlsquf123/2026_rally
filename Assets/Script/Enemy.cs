using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public int enemyType;
    public Image hpBar;

    float[] speeds = { 5f, 2f, 0.8f, 1.5f, 0.5f };
    float[] rotSpeeds = { 2f, 3f, 1f, 2f, 0.7f };
    float[] attackTimes = { 5f, 4f, 3f, 2f, 1f };
    float[] hps = { 20, 40, 80, 15, 60 };

    float speed;
    float rotSpeed;
    float attackTime;
    float hp;
    float maxHp;

    float timer = 0f;

    Transform player;
    public GameObject missilePrefab;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        speed = speeds[enemyType];
        rotSpeed = rotSpeeds[enemyType];
        attackTime = attackTimes[enemyType];
        maxHp = hps[enemyType];
        hp = maxHp;
    }

    void Update()
    {
        Vector3 dir = player.position - transform.position;

        Quaternion target = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, rotSpeed * Time.deltaTime);

        transform.Translate(0, 0, speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= attackTime)
        {
            Instantiate(missilePrefab, transform.position + transform.forward * 10, transform.rotation);
            timer = 0f;
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