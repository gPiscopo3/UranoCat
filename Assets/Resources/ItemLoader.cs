using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoader: MonoBehaviour
{

    public const string path = "Assets/Resources/cat_items.xml";
    ItemContainer catItemList { get; set; }
    
    void Awake()
    {
        
        catItemList = ItemContainer.LoadFromXml(path);
        Debug.Log($"Lista di CatItem deserializzata. Numero di oggetti: {catItemList.items.Count}");

    }

}
