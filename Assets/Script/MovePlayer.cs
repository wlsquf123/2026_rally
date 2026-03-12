using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float MoveSpeed = 50f;
    float RotationSpeed = 250f;
    float velocity = 0f;
    float rotVelocity = 0f;
    float moveTarget;
    float rotTarget;

    void Update()
    {
        rotTarget = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            velocity = MoveSpeed; // 즉시 최고속도
        }
        else
        {
            velocity = Mathf.Lerp(velocity, 0f, 2f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotTarget = -RotationSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotTarget = RotationSpeed;
        }

        rotVelocity = Mathf.Lerp(rotVelocity, rotTarget, 5f * Time.deltaTime);

        transform.Translate(0, 0, velocity * Time.deltaTime);
        transform.Rotate(0, rotVelocity * Time.deltaTime, 0);
    }
}