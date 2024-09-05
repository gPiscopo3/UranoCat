using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{

    Cat cat;    
    Player player;
   

    private static CatManager _instance;

    private float timer = 0f;

    bool lockUpdate = false;

    [SerializeField] private float hungerRate;
    [SerializeField] private float enjoymentRate;
    [SerializeField] private float happinessRate;

    
    void Start()
    {
        this.cat = FindObjectOfType<CatLoader>().cat;
    }

    // Private constructor to prevent instantiation from outside
    private CatManager() { }

    // Public static method to get the instance
    public static CatManager GetIstance()
    {
        {
            if (_instance == null)
            {
                _instance = new CatManager();
            }
            return _instance;
        }
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

            Debug.Log($"statistiche aggiornate: {cat.getStat(CatTag.SAZIETA).currentValue} {cat.getStat(CatTag.DIVERTIMENTO).currentValue} {cat.getStat(CatTag.FELICITA).currentValue}");
        }
        

       



        /*
        this.player = new Player(1,1,1); // Ad ogni Update ti prendi le informazioni per calcolare le statistiche

        // Successivamente dovrebbe essere per ogni oggetto attivo nell'inventario del giocatore. 
        foreach (CatItem cat in this.player.inventory)
        {
            foreach(CatModifier catModifier in cat.catModifiers)
            {
                modifiers.Add(catModifier);
            }
        }

        float partialDiverimento = 0;
        float partialFame = 0;
        float partialFelicita = 0;

        foreach(CatModifier catmodifier in modifiers.FindAll(obj => obj.targetStat == CatTag.SAZIETA))
        {
            partialFame += catmodifier.value;
        }
        foreach(CatModifier catmodifier in modifiers.FindAll(obj => obj.targetStat == CatTag.DIVERTIMENTO))
        {
            partialDiverimento += catmodifier.value;
        }
        foreach(CatModifier catmodifier in modifiers.FindAll(obj => obj.targetStat == CatTag.FELICITA))
        {
            partialFelicita += catmodifier.value;
        }

        this.cat.stats.Find(obj => obj.catTag == CatTag.SAZIETA).currentValue += partialFame; 
        this.cat.stats.Find(obj => obj.catTag == CatTag.DIVERTIMENTO).currentValue += partialDiverimento;
        this.cat.stats.Find(obj => obj.catTag == CatTag.FELICITA).currentValue += partialFelicita;
    */


    }

    public void ApplyModifier(CatModifier catModifier)
    {
        while(lockUpdate);
      
    
        
        cat.setStat(catModifier.targetStat,cat.getStat(catModifier.targetStat).currentValue + catModifier.value);

        Debug.Log($"statistiche aggiornate: {cat.getStat(CatTag.SAZIETA).currentValue} {cat.getStat(CatTag.DIVERTIMENTO).currentValue} {cat.getStat(CatTag.FELICITA).currentValue}");

        
       
    }



}
