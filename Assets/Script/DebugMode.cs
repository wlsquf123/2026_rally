using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    public GameObject box;

    public void DebugObj()
    {
        bool togle = !box.activeSelf;
        box.SetActive(togle);
    }
}
