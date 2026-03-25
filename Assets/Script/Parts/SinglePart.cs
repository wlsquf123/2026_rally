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
    NotBought,
    Bought,
    EquippedLeft,
    EquippedRight,
}

public class SinglePart : MonoBehaviour
{
    public PartType ThisPartType = PartType.Null;
    public PartState ThisPartState = PartState.Null;
    public string Description;
    public int Price = 0;
    public Image PartImage;
    public Button BuyButton;
    public Button LeftEquipButton;
    public Button RightEquipButton;
    public Text LeftQuickSlotTxt;
    public Text RightQuickSlotTxt;

    public void Buy()
    {
        if(ThisPartState == PartState.NotBought)
        {
            ThisPartState = PartState.Bought;
            BuyButton.gameObject.SetActive(false);

            LeftEquipButton.gameObject.SetActive(true);
            RightEquipButton.gameObject.SetActive(true);
        }
    }

}