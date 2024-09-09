using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class InventoryItem{

        public String ID;
        public Item item;

        public int numUses;
        
        public InventoryItem(Item item){
            Guid myuuid = Guid.NewGuid();
            ID = myuuid.ToString();
            this.item = item;
            numUses = 0;
        }

        public InventoryItem()
        {}

        public void useItem(){
            numUses ++;
        }

        public bool isUsable(){
            return numUses < item.durability || item.durability == 0;
        }

        public override bool Equals(object obj)
        {
    
            if (obj == null || GetType() != obj.GetType())
            {   
                return false;
            }
            
            return this.ID.Equals(((InventoryItem)obj).ID);
            
        }

        public bool EqualsByTag(Item item)
        {
            return this.item.tag.Equals(item.tag);
        }
     
        public override int GetHashCode()
        {
           return ID.GetHashCode();
        }
        
    }
