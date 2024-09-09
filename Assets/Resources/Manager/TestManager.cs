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
        /*this.player = FindObjectOfType<PlayerLoader>().player;

        List<CatItem> catItems = new List<CatItem>();

        List<CatModifier> modifiers = new List<CatModifier>();
        modifiers.Add(new CatModifier(CatTag.SAZIETA, 5));
        modifiers.Add(new CatModifier(CatTag.FELICITA, 0.1f));
        catItems.Add(new CatItem("ITEM001", "Crocchette Piccole", 
            "Piccola porzione di crocchette. Utilizzabile 10 volte", 10, modifiers));
       

        modifiers = new List<CatModifier>();
        modifiers.Add(new CatModifier(CatTag.SAZIETA, 8));
        modifiers.Add(new CatModifier(CatTag.DIVERTIMENTO, 1));
        modifiers.Add(new CatModifier(CatTag.FELICITA, 0.5f));
        catItems.Add(new CatItem("ITEM002", "Pesce", 
            "Un bel merluzzo da mangiare", 1, modifiers));

        modifiers = new List<CatModifier>();
        modifiers.Add(new CatModifier(CatTag.SAZIETA, -2));
        modifiers.Add(new CatModifier(CatTag.DIVERTIMENTO, 5));
        modifiers.Add(new CatModifier(CatTag.FELICITA, 0.5f));
        catItems.Add(new CatItem("ITEM003", "Topo di gomma", 
            "Un topo con cui giocare. Attenzione, fa venire fame!", 30, modifiers));

        
        XMLHelper.SaveToXml<List<CatItem>>(catItems, "Assets/Resources/cat_items.xml");


        List<ShopItem> shopItems = new List<ShopItem>
        {
            new ShopItem("ITEM001", 5, 1),
            new ShopItem("ITEM002", 5, 1),
            new ShopItem("ITEM003", 10, 10)
        };

        XMLHelper.SaveToXml<List<ShopItem>>(shopItems, "Assets/Resources/shop_items.xml");*/






     
        
    }
    

    void Update()
    {
        timer += Time.deltaTime;



        if (timer < -1)
        {

            Debug.Log(items[0].tag);

            Debug.Log(player.inventory);
           
            player.inventory.addItem(items[0]);

            timer = 0;
            player.equip(player.inventory.items[0]);
        
          
            
           
        }

    }


        

       



}
