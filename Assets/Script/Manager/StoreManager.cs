using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;

    public bool[] hasPart = new bool[5];
    public int[] PartMoney = {100, 110, 120, 130, 140 };
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Store(int index)
    {
        
        if (hasPart[index])
        {
            return;
        }
        if (GameManager.Instance.money >= PartMoney[index]) // 너 돈이 충분해?
        {
            GameManager.Instance.money -= PartMoney[index];
            hasPart[index] = true;
        }
    }
}
