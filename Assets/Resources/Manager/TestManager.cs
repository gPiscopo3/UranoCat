using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{

    

    Player player;
    List<CatItem> items;

    private float timer = 0f;

   

    
    void Start()
    {
        this.player = FindObjectOfType<PlayerLoader>().player;
        this.items = FindObjectOfType<ItemLoader>().catItemList.items;

        player.equip(player.inventory.items[0]);

     
        
    }
    

    void Update()
    {
        timer += Time.deltaTime;



        if (timer > 300f)
        {

            Debug.Log(items[0].tag);

            Debug.Log(player.inventory);
           
            player.inventory.addItem(items[0]);

            timer = 0;
            player.equip(player.inventory.items[0]);
        
          
            
           
        }

    }


        

       



}
