using UnityEngine;

public class Parrying : MonoBehaviour
{
    public GameObject parryingObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            Missile mis = other.GetComponent<Missile>();
            mis.TargetTransform = null;
            other.transform.forward = -other.transform.forward;
            GameObject eff = Instantiate(parryingObj, transform.position, transform.rotation);
            Destroy(eff, 3.0f);

            gameObject.SetActive(false);
        }
    }
}
