using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class SaveManager : MonoBehaviour
{


    

    GameLoader loader;
    SavedStats savedStats;

    private float timer_save = 0f;
    private float timer_timestamp = 0f;
    private int autosave;
   

    
    void Start()
    {
        this.loader = FindObjectOfType<GameLoader>();
        savedStats = loader.savedStats;
        
    }
    

    void Update()
    {
        
        timer_save += Time.deltaTime;
        
        timer_timestamp += Time.deltaTime;

        if(timer_timestamp >= 1){
            timer_timestamp = 0f;
            savedStats.timestamp_seconds ++;

        }

        if (timer_save > 10f)
        {

        
            SaveGame("auto"+autosave);
            autosave = (autosave + 1)%10;
            timer_save = 0f;
            

            
            
           
        }

        

    }

    public void SaveGame(String save){
        loader.SaveData(save);
    }

        

       



}
