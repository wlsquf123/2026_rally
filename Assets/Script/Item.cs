using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Items
    {
        None,
        hpItem, // 체력 회복 아이템
        godItem, // 무적 아이템
        guardItem // 방어 아이템
    }

    public Items type; // 아이템 타입

    float Speed = 8f;
    Vector3 dir;

    private void Start()
    {

        float randomX = Random.Range(-0.5f, 0.5f);
        float randomZ = Random.Range(-1f, -0.2f);
        dir = new Vector3(randomX, 0, randomZ).normalized;
        Destroy(gameObject, 15f);
    }

    private void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (type)
        {
            // Hp 회복
            case Items.hpItem:
                if (other.CompareTag("Player"))
                {
                    GameManager.Instance.PlayerHp += 30;
                    Destroy(gameObject);
                }
                break;
            // 일정 시간 무적
            case Items.godItem:
                if (other.CompareTag("Player"))
                {
                    MovePlayer player = other.GetComponent<MovePlayer>();
                    player.StartCoroutine(player.GodMode(10f));
                    Destroy(gameObject);
                }

                break;
           /* // 일정 시간 방어 아이템
            case Items.guardItem:
                if (other.CompareTag("Player"))
                {
                    MovePlayer player = other.GetComponent<MovePlayer>();
                    player.StartCoroutine(player.guardMode(5f));
                    Destroy(gameObject);
                }
                break;*/
        }
    }
}
