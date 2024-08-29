using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoader: MonoBehaviour
{

    public const string path = "items";
    List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Awake()
    {
        
        ItemContainer ic = ItemContainer.Load(path);

        foreach(Item item in ic.GetItems()){
            items.Add(item);
        }

    }

}
