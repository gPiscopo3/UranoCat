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
        
    }
    

    void Update()
    {
        timer += Time.deltaTime;



        if (timer > 5f)
        {

            Debug.Log(items[0].tag);
            timer = 0f;
            player.inventory.addItem(items[0]);

            Debug.Log(player.inventory.ToString());

            player.equip(items[0].tag);
        
          
            
           
        }

    }


        

       



}
