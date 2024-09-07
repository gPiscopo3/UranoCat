using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoader: MonoBehaviour
{

    public const string catPath = "Assets/Resources/cat_items.xml";
    public const string shopPath = "Assets/Resources/shop_Items.xml";
    //public ItemContainer catItemList { get; set; }

    public List<Item> items;
    public List<ShopItem> shopItems;

    
    void Awake()
    {
        
        items = new List<Item>();
        List<CatItem> catItemList = XMLHelper.LoadFromXml<List<CatItem>>(catPath);
        Debug.Log($"Lista di CatItem deserializzata con {catItemList.Count}");

        items.AddRange(catItemList);


        this.shopItems =  XMLHelper.LoadFromXml<List<ShopItem>>(shopPath);
        Debug.Log($"Lista di ShopItem deserializzata. Numero di elementi: {this.shopItems.Count}");
        foreach(ShopItem shopItem in shopItems){
            shopItem.item = GetItem(shopItem.Tag);
        }

        

        

    }


    public Item GetItem(string tag){
        foreach(Item item in items){
            if(item.tag.Equals(tag))
                return item;
        }
        return null;
    }





}
