using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CatManager : MonoBehaviour
{

    Cat cat;    
    Player player;

    Rules rules;

    private float timer_update = 0f;
    private float timer_iteractions = 0f;
    private int iteractions_availables = 1;

    bool lockUpdate = false;

    Stack<CatModifier> modifiers;

    private VideoManager videoManager;    




    
    void Start()
    {
        this.cat = FindObjectOfType<SaveLoader>().cat;
        this.rules = FindObjectOfType<AssetsLoader>().rules;
        this.videoManager = FindObjectOfType<VideoManager>();
        this.modifiers = new Stack<CatModifier>();
    }
    

    void Update()
    {
        timer_update += Time.deltaTime;

        if(iteractions_availables < rules.max_interactions)
            timer_iteractions += Time.deltaTime;

        if (timer_update > rules.update_cat_time)
        {

            timer_update = 0f;
            List<CatStat> newStats = UpdateStats(cat, rules.cat_stats_rules.rules);
            cat.stats = newStats;
            
        }

        if(timer_iteractions > rules.interaction_cat_time){

            timer_iteractions = 0f;
            iteractions_availables ++;

        }

        if(modifiers.Count > 0){
            CatModifier catModifier = modifiers.Pop();
            cat.setStat(catModifier.targetStat,cat.getStat(catModifier.targetStat).currentValue + catModifier.value);
        }



   


    }



    public void Interact(){

        InventoryItem item = player.equippedItem;

        if(iteractions_availables > 0 && item != null){

            if(item.item.GetType() == typeof(CatItem)){
                CatItem catItem = (CatItem)item.item;
                foreach(CatModifier modifier in catItem.catModifiers)
                    ApplyModifier(modifier);
                    
                player.inventory.useItem(item);
                if(!item.isUsable())
                     player.unequip();
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
