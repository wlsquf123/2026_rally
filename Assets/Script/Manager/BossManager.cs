using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject BossObj;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0 && BossObj != null)
        {
            BossObj.SetActive(true);
            Destroy(gameObject);
        }
    }
}
