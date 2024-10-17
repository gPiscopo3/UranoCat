using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class CatManager : MonoBehaviour
{

    Cat cat;    
    Player player;

    Rules rules;

    Stack<CatModifier> modifiers;

    private DayManager dayManager;    
    SavedStats savedStats;

    List<Video> videos;

    
    void Start()
    {
        this.cat = FindObjectOfType<GameLoader>().cat;
        this.player = FindObjectOfType<GameLoader>().player;
        this.rules = FindObjectOfType<GameLoader>().rules;
        this.dayManager = FindObjectOfType<DayManager>();
        this.modifiers = new Stack<CatModifier>();
        this.savedStats = FindAnyObjectByType<GameLoader>().savedStats;
        this.videos = FindAnyObjectByType<GameLoader>().videos;
    }
    

    void Update()
    {
        savedStats.update_cat_timer += Time.deltaTime;


        if (savedStats.update_cat_timer > rules.update_cat_time)
        {

            savedStats.update_cat_timer = 0f;
            List<CatStat> newStats = UpdateStats(cat, rules.cat_stats_rules.rules);
            cat.stats = newStats;
            
        }


        while(modifiers.Count > 0){
            CatModifier catModifier = modifiers.Pop();
            cat.setStat(catModifier.targetStat,cat.getStat(catModifier.targetStat).currentValue + catModifier.value);
        }

    }



    public void Interact(){
        
        InventoryItem item = player.equippedItem;
        player.experience += 10;
     

        if(dayManager.isInteractionAvailable(InteractionType.CAT_ITERACTION) && item != null && item.item.GetType() == typeof(CatItem)){

            CatItem catItem = (CatItem)item.item;
            foreach(CatModifier modifier in catItem.catModifiers)
                ApplyModifier(modifier);
                    
            player.inventory.useItem(item);
            if(!item.isUsable())
                 player.unequip();
            
            dayManager.consumeInteraction(InteractionType.CAT_ITERACTION);
        }


        if(dayManager.isInteractionAvailable(InteractionType.VIDEO) && item!=null && item.item.GetType() == typeof(Smartphone)){
            CreateVideo();
            player.equippedItem = null;
            dayManager.consumeInteraction(InteractionType.VIDEO);

        }

    }

    public void ApplyModifier(CatModifier catModifier)
    {
        cat.setStat(catModifier.targetStat,cat.getStat(catModifier.targetStat).currentValue + catModifier.value);
    }

    public void CreateVideo(){
        Video video = VideoUtilis.createVideo(player.followers, cat, rules.social_rules, savedStats);
        videos.Add(video);
    }

    

    private List<CatStat> UpdateStats(Cat cat, List<CatStatsRules.StatRule> rules){

        List<CatStat> newStats = new List<CatStat>();
        foreach(CatStatsRules.StatRule statRule in rules){


            float newValue = 0;
            foreach(CatStatsRules.StatModifierRule modifierRule in statRule.modifiers){

                newValue += cat.getStat(modifierRule.tag).currentValue*modifierRule.value;
            }

            newStats.Add(new CatStat(newValue, cat.getStat(statRule.tag).maxValue, cat.getStat(statRule.tag).catTag));
        }

        return newStats;
    }

}
