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

    private VideoManager videoManager;    
    SavedStats savedStats;




    
    void Start()
    {
        this.cat = FindObjectOfType<SaveLoader>().cat;
        this.player = FindObjectOfType<SaveLoader>().player;
        this.rules = FindObjectOfType<AssetsLoader>().rules;
        this.videoManager = FindObjectOfType<VideoManager>();
        this.modifiers = new Stack<CatModifier>();
        savedStats = FindAnyObjectByType<SaveLoader>().savedStats;
    }
    

    void Update()
    {
        savedStats.update_cat_timer += Time.deltaTime;

        
        if(savedStats.interactions_cat < rules.max_interactions)
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

            else if(item.item.GetType() == typeof(Smartphone))
            {
                
            }


        }


            
    }

    public void ApplyModifier(CatModifier catModifier)
    {
    
        cat.setStat(catModifier.targetStat,cat.getStat(catModifier.targetStat).currentValue + catModifier.value);

        Debug.Log($"statistiche aggiornate: {cat.getStat(CatTag.SAZIETA).currentValue} {cat.getStat(CatTag.DIVERTIMENTO).currentValue} " + 
            $"{cat.getStat(CatTag.FELICITA).currentValue}");
        
       
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
