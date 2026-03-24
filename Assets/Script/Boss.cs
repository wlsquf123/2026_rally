using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject boomEff;
    private void OnTriggerEnter(Collider other)
    {
        Enemy Enemy = GetComponent<Enemy>();
        if (other.CompareTag("Player"))
        {
            GameObject eff = Instantiate(boomEff, transform.position, transform.rotation);
            Destroy(eff, 2f);
            Enemy.Damage(20f);
        }
    }
}
