using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{

    [SerializeField] Image imageItem;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text description;
    [SerializeField] Button priceButton;
    [SerializeField] TMP_Text price;


    

    public void SetShopItemPosition(Vector2 pos){

    
        GetComponent<RectTransform>().anchoredPosition += pos;

    }

    public void SetShopItemImage (Sprite sprite){

        imageItem.sprite = sprite;
        this.imageItem.GetComponent<Image>().enabled = true;

    }

    public void SetShopItemName(string name){

        this.itemName.text = name;
        this.itemName.enabled = true;
    }

    public void SetShopItemDescription(string description){

        this.description.text = description;
        this.description.enabled = true;
    }

    public void SetShopItemPrice(long price){


        this.price.text = price.ToString();
        this.priceButton.GetComponent<Image>().enabled = true;
        this.priceButton.enabled = true;
        
    }


    public void BuyShopItem(){

        priceButton.onClick.AddListener(Acquista);
    }

    private void Acquista(){
        
        Debug.Log(this.itemName + " comprato!");
    }




  
}
