using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Enemy Enemy = GetComponent<Enemy>();
        if (other.CompareTag("Player"))
        {
            Enemy.Damage(20f);
        }
    }
}
