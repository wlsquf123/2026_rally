using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject BossObj;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0 && BossObj)
        {
            BossObj.SetActive(true);
            Destroy(gameObject);
        }
    }
}
