using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleHoming : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            Missile mis = other.GetComponent<Missile>();
            mis.Homing(transform.parent);
        }
    }
}
