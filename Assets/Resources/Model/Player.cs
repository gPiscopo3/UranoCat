using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player
{

    public int level; 
    public int followers;
    public long money; 

    public CatItem equippedItem;
    

    [XmlElement("inventory")]
    public Inventory inventory; 
    public Player() {}   

    public void equip(String tag){
        equippedItem = (CatItem)inventory.GetItem(tag);
    }

    public void unequip(){
        equippedItem = null;
    }

    
}
