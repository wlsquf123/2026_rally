using UnityEngine;

public class UIKeepRotation : MonoBehaviour
{
    Vector3 offset;
    Quaternion fixedRotation;

    void Start()
    {
        offset = transform.position - transform.parent.position;
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
            transform.position = transform.parent.position + offset;
            transform.rotation = fixedRotation;
    }
}