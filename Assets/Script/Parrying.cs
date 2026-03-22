using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrying : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            Missile mis = other.GetComponent<Missile>();
            mis.TargetTransform = null;
            other.transform.forward = -other.transform.forward;
            gameObject.SetActive(false);
        }
    }
}
