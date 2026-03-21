using UnityEngine;

public class HomingModule : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Missile[] allMissiles = GameObject.FindObjectsOfType<Missile>();
            foreach (Missile mis in allMissiles)
            {
                mis.TargetTransform = other.transform;
                mis.Homing(other.transform);
            }
            gameObject.SetActive(false);
        }
    }
}
