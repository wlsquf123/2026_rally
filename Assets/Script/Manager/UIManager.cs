using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image PlayerHpImage; // 체력바 이미지
    public Text PlayerMoneyText;
    public Text PlayerMoneyTextStore;
    public Text QuickSlotText;

    public GameObject GameOverObj;
    public GameObject StageClearObj;

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
        //UpdateQuickSlotUI();
    }

    public void PlayerHpUI()
    {
        PlayerHpImage.fillAmount = GameManager.Instance.PlayerHp / GameManager.Instance.PlayerMaxHp;
    }
    
    public void PlayerMoneyTextUI()
    {
        PlayerMoneyText.text = GameManager.Instance.money.ToString();
        PlayerMoneyTextStore.text = GameManager.Instance.money.ToString();
    }

    public void GAMEOVERUI()
    {
        GameOverObj.SetActive(true);
    }

    public void StageClearUI()
    {
        StageClearObj.SetActive(true);
        Time.timeScale = 0f; // 게임 일시정지
    }

    /*public void UpdateQuickSlotUI()
    {
        // 상점 스크립트 참조
        Store shop = FindObjectOfType<Store>();
        if (shop == null) return;

        string equippedNames = "장착 파츠: ";
        int foundCount = 0;

        // 상점의 모든 파츠를 검사
        foreach (var part in shop.parts)
        {
            if (part.isEquipped)
            {
                equippedNames += "[" + part.type.ToString() + "] ";
                foundCount++;
            }
        }

        // 장착된 게 하나도 없다면
        if (foundCount == 0)
        {
            QuickSlotText.text = "장착된 파츠 없음";
        }
        else
        {
            QuickSlotText.text = equippedNames;
        }
    }*/
}
