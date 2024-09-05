using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemLoader : MonoBehaviour
{
    
    public const string path = "Assets/Resources/shopItemsData.xml";
    List<ShopItem> shopItems; 

    void Awake()
    {
        
        this.shopItems =  XMLHelper.LoadShopItemsFromXml(path);
        Debug.Log($"Lista di ShopItem deserializzata. Numero di elementi: {this.shopItems.Count}");

    }

}