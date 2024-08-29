using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem
{

    public string tag;
    public string name;
    public string description;
    public long price;
    public int minLevelRequired; 

    public ShopItem(string tag, string name, string description, long price, int minLevelRequired)
    {
        this.tag = tag;
        this.name = name;
        this.description = description;
        this.price = price;
        this. minLevelRequired = minLevelRequired;
    }

}
