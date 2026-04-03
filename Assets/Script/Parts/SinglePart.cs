using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PartType
{
    Null = 0,
    Homing,
    TimeStop,
    Reflector,
    BlackHole,
    SlowField
}

public enum PartState
{
    Null = 0,
    NotBought, // 안산 상태
    Bought, // 산 상태
    EquippedLeft, // 왼쪽낌
    EquippedRight, // 오른쪽 낌
}

public class SinglePart : MonoBehaviour
{
    public PartType ThisPartType; // 파츠타입
    public PartState ThisPartState; // 파츠 상태

    public int Price = 0; // 가격

    public Image PartImage; // 파츠 이미지

    public Button BuyButton; // 구매 버튼
    public Button LeftEquipButton; // 왼쪽버튼
    public Button RightEquipButton; // 오른쪽 버튼

    public Text LeftQuickSlotTxt;
    public Text RightQuickSlotTxt;

    public void Buy()
    {
        if(ThisPartState == PartState.NotBought) // 지금 구매상태가 아니지? 그러면 구매하면 중복 방지를 위해 상태를 바꾸자
        {
            ThisPartState = PartState.Bought;

            BuyButton.gameObject.SetActive(false); // 구매버튼 비활성
            LeftEquipButton.gameObject.SetActive(true); // 왼쪽버튼 활성
            RightEquipButton.gameObject.SetActive(true); // 오른쪽버튼 활성
        }
    }
}