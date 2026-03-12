using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image PlayerHpImage;

    Quaternion initialRotation;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        PlayerHpUI();
    }

    public void PlayerHpUI()
    {
        PlayerHpImage.fillAmount = GameManager.Instance.PlayerHp / GameManager.Instance.PlayerMaxHp;
    }

}
