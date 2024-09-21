using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CatManager : MonoBehaviour
{

    Cat cat;    
    Player player;

    Rules rules;

   
    bool lockUpdate = false;

    Stack<CatModifier> modifiers;

    private DayManager dayManager;    
    SavedStats savedStats;




    
    void Start()
    {
        this.cat = FindObjectOfType<SaveLoader>().cat;
        this.player = FindObjectOfType<SaveLoader>().player;
        this.rules = FindObjectOfType<AssetsLoader>().rules;
        this.dayManager = FindObjectOfType<DayManager>();
        this.modifiers = new Stack<CatModifier>();
        this.savedStats = FindAnyObjectByType<SaveLoader>().savedStats;
    }
    

    void Update()
    {
        savedStats.update_cat_timer += Time.deltaTime;

        
        if(savedStats.interactions_cat < rules.max_interactions_stackables)
            savedStats.interaction_cat_timer += Time.deltaTime;

        if (savedStats.update_cat_timer > rules.update_cat_time)
        {

            savedStats.update_cat_timer = 0f;
            List<CatStat> newStats = UpdateStats(cat, rules.cat_stats_rules.rules);
            cat.stats = newStats;
            
        }

        if(savedStats.interaction_cat_timer > rules.interaction_cat_time){

            savedStats.interaction_cat_timer = 0f;
            savedStats.interactions_cat ++;

        }

        while(modifiers.Count > 0){
            CatModifier catModifier = modifiers.Pop();
            cat.setStat(catModifier.targetStat,cat.getStat(catModifier.targetStat).currentValue + catModifier.value);
        }



   


    }



    public void Interact(){

        InventoryItem item = player.equippedItem;
        player.experience += 10;

        if(savedStats.interactions_cat > 0 && item != null){

            if(item.item.GetType() == typeof(CatItem)){
                CatItem catItem = (CatItem)item.item;
                foreach(CatModifier modifier in catItem.catModifiers)
                    ApplyModifier(modifier);
                    
                player.inventory.useItem(item);
                if(!item.isUsable())
                     player.unequip();

                savedStats.interactions_cat--;
            }

            else if(item.item.GetType() == typeof(Smartphone) && savedStats.videoStatus == EventStatus.AVAILABLE)
            {
                savedStats.interactions_cat--;
                CreateVideo();
            }


        }


            
    }

    public void ApplyModifier(CatModifier catModifier)
    {
    
        cat.setStat(catModifier.targetStat,cat.getStat(catModifier.targetStat).currentValue + catModifier.value);

        Debug.Log($"statistiche aggiornate: {cat.getStat(CatTag.SAZIETA).currentValue} {cat.getStat(CatTag.DIVERTIMENTO).currentValue} " + 
            $"{cat.getStat(CatTag.FELICITA).currentValue}");
        
       
    }

     public void CreateVideo(){

        double quality = 0;
        foreach(SocialRules.QualityRule qualityRule in rules.social_rules.quality_rules){

            quality += qualityRule.factor * cat.getStat(qualityRule.stat).currentValue / 100;
        }

        Video video = new Video{
            day = savedStats.day, 
            quality = quality,
            views = (long)(rules.social_rules.a_factor*player.followers*quality),
            today_views = 0,
            timestamp_seconds = savedStats.timestamp_seconds
        };

        dayManager.VideoRegistrato();



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
