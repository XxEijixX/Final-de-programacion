using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemName;
    public TMP_Text itemDescription;

    public void SetItemInfo(Item item)
    {
        itemImage.sprite = item._sprite;
        itemName.text = item._name;
        itemDescription.text = item._description;
    }

}
