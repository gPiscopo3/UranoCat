using System.Collections.Generic;

public class Inventory
{
    public List<InventoryItem> items;
    
    public Inventory(){
        items = new List<InventoryItem>();
    }

    public void addItem(Item item){

        items.Add(new InventoryItem(item));

    }

    public void useItem(InventoryItem item){
        
        if(items.Contains(item)){
           item.useItem();
           if(!item.isUsable())
            items.Remove(item);
        }

    }
}
