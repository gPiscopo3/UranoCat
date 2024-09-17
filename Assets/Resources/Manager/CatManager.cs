using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CatManager : MonoBehaviour
{

    Cat cat;    
    Player player;

    CatStatsRules rules;

    private float timer = 0f;

    bool lockUpdate = false;




    
    void Start()
    {
        this.cat = FindObjectOfType<CatLoader>().cat;
        this.rules = FindObjectOfType<RulesLoader>().catStatsRules;
        Debug.Log(cat);
        Debug.Log(rules);
    }
    

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > rules.seconds)
        {

        
            timer = 0f;

            lockUpdate = true;
          
            /*cat.setStat((CatTag.SAZIETA),cat.getStat(CatTag.SAZIETA).currentValue * hungerRate);
            cat.setStat((CatTag.DIVERTIMENTO), cat.getStat(CatTag.DIVERTIMENTO).currentValue * enjoymentRate);

            float happinessRate = 
                1 + ((cat.getStat(CatTag.SAZIETA).currentValue + cat.getStat(CatTag.DIVERTIMENTO).currentValue )/cat.getStat(CatTag.FELICITA).currentValue - 1)/happinessRateIterations;
                
            cat.setStat((CatTag.FELICITA), cat.getStat(CatTag.FELICITA).currentValue * happinessRate);*/

            List<CatStat> newStats = UpdateStats(cat, rules.rules);

            cat.stats = newStats;
            

            lockUpdate = false;

            Debug.Log($"statistiche aggiornate: {cat.getStat(CatTag.SAZIETA).currentValue} {cat.getStat(CatTag.DIVERTIMENTO).currentValue} " + 
                $"{cat.getStat(CatTag.FELICITA).currentValue}");
        }

   


    }

    public void ApplyModifier(CatModifier catModifier)
    {
        while(lockUpdate);
      
    
        
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
