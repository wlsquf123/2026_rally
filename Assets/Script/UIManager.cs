using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image PlayerHpImage; // 체력바 이미지
    public Text PlayerMoneyText;

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
        PlayerMoneyTextUI();
    }

    public void PlayerHpUI()
    {
        PlayerHpImage.fillAmount = GameManager.Instance.PlayerHp / GameManager.Instance.PlayerMaxHp;
    }

    public void PlayerMoneyTextUI()
    {
        PlayerMoneyText.text = GameManager.Instance.money.ToString();
    }
}
