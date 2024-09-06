using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatManager : MonoBehaviour
{

    Cat cat;    
    Player player;

    private float timer = 0f;

    bool lockUpdate = false;

    [SerializeField] private float hungerRate;
    [SerializeField] private float enjoymentRate;
    [SerializeField] private float happinessRate;

    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider enjoymentSlider;
    [SerializeField] private Slider happinessSlider;


    
    void Start()
    {
        this.cat = FindObjectOfType<CatLoader>().cat;
    }
    

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10f)
        {

        
            timer = 0f;

            lockUpdate = true;
            // da decidere la funzione di aggiornamento delle statistiche
            cat.setStat((CatTag.SAZIETA),cat.getStat(CatTag.SAZIETA).currentValue * hungerRate);
            cat.setStat((CatTag.DIVERTIMENTO), cat.getStat(CatTag.DIVERTIMENTO).currentValue * enjoymentRate);
            cat.setStat((CatTag.FELICITA), cat.getStat(CatTag.FELICITA).currentValue * happinessRate);
            

            lockUpdate = false;

            Debug.Log($"statistiche aggiornate: {cat.getStat(CatTag.SAZIETA).currentValue} {cat.getStat(CatTag.DIVERTIMENTO).currentValue} " + 
                $"{cat.getStat(CatTag.FELICITA).currentValue}");
        }

        hungerSlider.value = cat.getStat(CatTag.SAZIETA).currentValue;
        enjoymentSlider.value = cat.getStat(CatTag.DIVERTIMENTO).currentValue;
        happinessSlider.value = cat.getStat(CatTag.FELICITA).currentValue;
        


    }

    public void ApplyModifier(CatModifier catModifier)
    {
        while(lockUpdate);
      
    
        
        cat.setStat(catModifier.targetStat,cat.getStat(catModifier.targetStat).currentValue + catModifier.value);

        Debug.Log($"statistiche aggiornate: {cat.getStat(CatTag.SAZIETA).currentValue} {cat.getStat(CatTag.DIVERTIMENTO).currentValue} " + 
            $"{cat.getStat(CatTag.FELICITA).currentValue}");
        
       
    }



}
