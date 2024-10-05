using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemRequiredUI : MonoBehaviour
{

    [SerializeField] Image image;
    [SerializeField] TMP_Text quantity;

    public void SetImage(string imagePath){
        image.sprite = Resources.Load<Sprite>("Images/" + imagePath);
        image.enabled = true;
    }

    public void SetQuantity(string quantity){
        this.quantity.text = quantity;
        this.quantity.enabled = true;
    }

    public void SetPositionItem(Vector2 pos){
        GetComponent<RectTransform>().anchoredPosition += pos;
    }


}

