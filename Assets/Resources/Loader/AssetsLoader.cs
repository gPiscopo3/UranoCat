using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AssetsLoader: MonoBehaviour
{

    public const string catPath = "Assets/Resources/cat_items.xml";
    public const string shopPath = "Assets/Resources/shop_items.xml";
    public const string keyPath = "Assets/Resources/key_items.xml";
    public const string RulesPath = "Assets/Resources/rules.xml";
    public List<Item> items;
    public List<ShopItem> shopItems;
    public Rules rules;


    

    
    void Awake()
    {
        
        items = new List<Item>();
        List<CatItem> catItemList = XMLHelper.LoadFromXml<List<CatItem>>(catPath);
        Debug.Log($"Lista di CatItem deserializzata con {catItemList.Count}");

        items.AddRange(catItemList);

        List<KeyItem> keyItems = XMLHelper.LoadFromXml<List<KeyItem>>(keyPath);
        Debug.Log($"Lista di KeyItem deserializzata con {keyItems.Count}");
        items.AddRange(keyItems);
        

        this.shopItems =  XMLHelper.LoadFromXml<List<ShopItem>>(shopPath);
        Debug.Log($"Lista di ShopItem deserializzata. Numero di elementi: {this.shopItems.Count}");
        foreach(ShopItem shopItem in shopItems){
            shopItem.item = GetItem(shopItem.Tag);
        }

        this.rules = XMLHelper.LoadFromXml<Rules>(RulesPath);

        

        

    }


    public Item GetItem(string tag){
        foreach(Item item in items){
            if(item.tag.Equals(tag))
                return item;
        }
        return null;
    }





}
