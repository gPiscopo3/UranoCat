using System;
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
    long priceValue;
    string tag;

    


    public void setTag(string tag){
        this.tag = tag;
    }

    public void SetShopItemPosition(Vector2 pos){

    
        GetComponent<RectTransform>().anchoredPosition += pos;

    }

    public void SetShopItemImage (string imagePath){

        Sprite sprite = Resources.Load(imagePath, typeof(Sprite)) as Sprite;
        
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

        this.priceValue = price;
        this.price.text = price.ToString();
        this.priceButton.GetComponent<Image>().enabled = true;
        this.priceButton.enabled = true;
        priceButton.onClick.AddListener(Acquista);
        
    }

    public void SetShopItemLevelNotEoungh(int level){
        this.price.text = "Liv " + level.ToString();
    }



    private void Acquista(){
        
        long price = this.priceValue;
        Player player = FindObjectOfType<PlayerLoader>().player;
        Item item = FindAnyObjectByType<ItemLoader>().GetItem(tag);
        if(player.money >= price && item!=null){
            player.money = player.money - price;
            player.inventory.addItem(item);
            Debug.Log(this.itemName.text + " comprato!");
            
        }
        
    }

}
