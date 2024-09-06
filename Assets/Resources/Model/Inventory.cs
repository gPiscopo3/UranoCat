using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Inventory
{
    

    [XmlElement("items")]
    public Dictionary<String, List<Item>> items;
    

    public Inventory(){
        items = new Dictionary<string, List<Item>>();
    }

    public void addItem(Item item){

        if(!items.ContainsKey(item.tag))
            items.Add(item.tag, new List<Item>());
        items[item.tag].Add(item);

    }

    public Item GetItem(String tag){

        if(items.ContainsKey(tag)){
            return items[tag][0];
        }
        return null;
    }


    public void useItem(String tag){
        
        if(items.ContainsKey(tag)){
            List<Item> list = items[tag];
            if(list.Count>0)
                list[0].useItem();
                if(!list[0].isUsable())
                    list.RemoveAt(0);
            if(list.Count == 0)
                items.Remove(tag);
        }

    }

    

}
