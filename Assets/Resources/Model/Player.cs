using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player
{

    public int level; 
    public long followers;
    public double money; 
    public double pension;
    public long experience;
    
    public float x, y, z;

    [XmlIgnore] public InventoryItem equippedItem;

    public Inventory inventory; 
    public Player() {

    }   

    public void equip(InventoryItem item){
        equippedItem = item;
    }

    public void unequip(){
        equippedItem = null;
    }
   
}
