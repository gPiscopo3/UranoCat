using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Inventory
{
    
    Dictionary<CatItem, int> catItems;
    

    public Inventory(){}

    public void addCatItem(CatItem item, int quantity){

        if(!catItems.ContainsKey(item))
            catItems.Add(item, quantity);
        else
            catItems[item] = catItems[item] + quantity;

    }

    public void removeCatItem(CatItem item){
        
        if(catItems.ContainsKey(item)){
            catItems[item] --;
            if(catItems[item] == 0)
            catItems.Remove(item);
        }

    }

    

}
