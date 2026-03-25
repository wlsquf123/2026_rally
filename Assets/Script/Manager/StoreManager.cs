using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{

    public List<SinglePart> Parts;
    
    public Image LeftQuickSlotImage;
    public Image RightQuickSlotImage;

    
    public void TryToBuyThisPart(SinglePart targetPart)
    {
        if (targetPart.Price <= GameManager.Instance.money)
        {
            targetPart.Buy();
            GameManager.Instance.money -= targetPart.Price;
        }
    }

    public void TryToEquipLeftSlot(SinglePart targetPart)
    {
        switch (targetPart.ThisPartState)
        {
            case PartState.Bought:
                LeftQuickSlotImage.sprite = targetPart.PartImage.sprite;
                targetPart.ThisPartState = PartState.EquippedLeft;
                targetPart.LeftQuickSlotTxt.text = "ÀåÂø ÇØÁ¦";
                break;

            case PartState.EquippedLeft:
                LeftQuickSlotImage.sprite = null;
                targetPart.ThisPartState = PartState.Bought;
                targetPart.LeftQuickSlotTxt.text = "1¹ø ÀåÂø";
                break;

            case PartState.EquippedRight:
                RightQuickSlotImage.sprite = null;
                LeftQuickSlotImage.sprite = targetPart.PartImage.sprite;
                targetPart.ThisPartState = PartState.EquippedLeft;
                targetPart.RightQuickSlotTxt.text = "2¹ø ÀåÂø";
                targetPart.LeftQuickSlotTxt.text = "ÀåÂø ÇØÁ¦";
                break;
        }
    }

    public void TryToEquipRightSlot(SinglePart targetPart)
    {
        switch (targetPart.ThisPartState)
        {
            case PartState.Bought:
                RightQuickSlotImage.sprite = targetPart.PartImage.sprite;
                targetPart.ThisPartState = PartState.EquippedRight;
                targetPart.RightQuickSlotTxt.text = "ÀåÂø ÇØÁ¦";
                break;

            case PartState.EquippedRight:
                RightQuickSlotImage.sprite = null;
                targetPart.ThisPartState = PartState.Bought;
                targetPart.RightQuickSlotTxt.text = "2¹ø ÀåÂø";
                break;

            case PartState.EquippedLeft:
                LeftQuickSlotImage.sprite = null;
                RightQuickSlotImage.sprite = targetPart.PartImage.sprite;
                targetPart.ThisPartState = PartState.EquippedRight;
                targetPart.LeftQuickSlotTxt.text = "1¹ø ÀåÂø";
                targetPart.RightQuickSlotTxt.text = "ÀåÂø ÇØÁ¦";
                break;
        }
    }
}