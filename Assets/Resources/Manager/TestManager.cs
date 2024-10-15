using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CatStatsRules;

public class TestManager : MonoBehaviour
{

    

    Player player;
    List<CatItem> items;
    private Cat cat;

    private float timer = 0f;
    private SavedStats savedStats;
    private Rules rules;
    private List<Video> videos;
    private DayManager dayManager;

   
   public void Awake(){

    

    List<InteractionType> interactionToComplete = new List<InteractionType>
    {
        InteractionType.SLEEP
    };

    List<Interaction> interactions = new List<Interaction>{

        new Interaction{interactionType = InteractionType.CAT_ITERACTION, dayTime = 60},
        new Interaction{interactionType = InteractionType.VIDEO, dayTime = 120},
        new Interaction{interactionType = InteractionType.CAT_ITERACTION, dayTime = 180},
        new Interaction{interactionType = InteractionType.SLEEP, dayTime = 240}

    };

    Rules rules = new Rules(){
        interactionsTimes = interactions,
        interactionsToComplete = interactionToComplete,
    };

    XMLHelper.SaveToXml(rules, "rules1.xml");

    

   }

    
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

        /*CatStatsRules catStatsRules = new CatStatsRules();

        catStatsRules.seconds = 10;
        catStatsRules.rules = new List<StatRule>(){new StatRule()};
        catStatsRules.rules[0].tag = CatTag.SAZIETA;
        catStatsRules.rules[0].modifiers = new List<StatModifierRule>(){new StatModifierRule()};
        catStatsRules.rules[0].modifiers[0].tag = CatTag.SAZIETA;
        catStatsRules.rules[0].modifiers[0].value = 0.9f;
        XMLHelper.SaveToXml<CatStatsRules>(catStatsRules, "Assets/Resources/cat_rules.xml");*/

        savedStats = FindObjectOfType<GameLoader>().savedStats;
        player = FindObjectOfType<GameLoader>().player;
        rules = FindObjectOfType<GameLoader>().rules;
        videos = FindObjectOfType<GameLoader>().videos;
        cat = FindObjectOfType<GameLoader>().cat;

        dayManager = FindObjectOfType<DayManager>();







     
        
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

        /*if(timer > 0.5f){
            if(savedStats.videoStatus.Equals(InteractionStatus.AVAILABLE)){
                Video video = VideoUtilis.createVideo(player.followers, cat, rules.social_rules, savedStats);   
                videos.Add(video);
                dayManager.VideoRegistrato();
            }
        timer = 0f;
        }*/

    

    }


        

       



}
