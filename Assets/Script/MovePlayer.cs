using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject HomingModule; // 강제 유도
    public GameObject Parrying; // 반사
    public GameObject god; // 무적
    // public GameObject guard; // 방어

    public bool IsCoroutineRunnin = false;

    public float MoveSpeed = 50f;
    float RotationSpeed = 250f;
    float velocity = 0f;
    float rotVelocity = 0f;
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

    public void EnableHomingModule()
    {
        if (HomingModule.activeSelf) // 만약 HomingModule이 체크박스가 켜져있다면,
        {
            return; // 돌아가라 안받는다
        }
        else
        {
            HomingModule.SetActive(true); // 그게 아니면 채크박스를 켜라
        }

    }

    public void EnableParrying()
    {
        if (Parrying.activeSelf)
        {
            return ;
        }
        StartCoroutine(ParryRoutine(0.3f));
    }

    public IEnumerator ParryRoutine(float duration) 
    {
        Parrying.SetActive(true); // 패링 오브젝트 켜기

        yield return new WaitForSeconds(duration); // duration만큼 대기

        // 만약 미사일에 부딪혀서 이미 꺼진 게 아니라면 여기서 끔
        if (Parrying != null)
        {
            Parrying.SetActive(false);
        }
    }

    public IEnumerator GodMode(float delay) // 무적모드 아이템
    {
        IsCoroutineRunnin = true;
        god.SetActive(true);

        yield return new WaitForSeconds(delay);

        god.SetActive(false);
        IsCoroutineRunnin = false;
    }

/*    public IEnumerator guardMode(float delay)
    {
        IsCoroutineRunnin = true;
        guard.SetActive(true);

        yield return new WaitForSeconds(delay);

        guard.SetActive(false);
        IsCoroutineRunnin = false;
    }*/

    public void GodModeToggle() // 무적모드(토글방식)
    {
        bool nextState = !god.activeSelf;
        god.SetActive(nextState);
    }
}
