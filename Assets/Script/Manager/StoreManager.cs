using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;

    public List<SinglePart> Parts;

    public Image LeftQuickSlotImage;
    public Image RightQuickSlotImage;

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
                break;

            case PartState.EquippedLeft:
                LeftQuickSlotImage.sprite = null;
                targetPart.ThisPartState = PartState.Bought;
                break;

            case PartState.EquippedRight:
                RightQuickSlotImage.sprite = null;
                LeftQuickSlotImage.sprite = targetPart.PartImage.sprite;
                targetPart.ThisPartState = PartState.EquippedLeft;
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
                break;

            case PartState.EquippedRight:
                RightQuickSlotImage.sprite = null;
                targetPart.ThisPartState = PartState.Bought;
                break;

            case PartState.EquippedLeft:
                LeftQuickSlotImage.sprite = null; // ¿ÞÂÊ ºñ¿ì±â
                RightQuickSlotImage.sprite = targetPart.PartImage.sprite;
                targetPart.ThisPartState = PartState.EquippedRight;
                break;
        }
    }
}