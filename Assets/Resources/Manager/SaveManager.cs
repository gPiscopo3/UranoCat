using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class SaveManager : MonoBehaviour
{


    

    SaveLoader loader;
    SavedStats savedStats;

    private float timer_save = 0f;
    private float timer_timestamp = 0f;

   

    
    void Start()
    {
        this.loader = FindObjectOfType<SaveLoader>();
        savedStats = loader.savedStats;
        
    }
    

    void Update()
    {
        timer_save += Time.deltaTime;
        
        timer_timestamp += Time.deltaTime;

        if (timer_save > 10f)
        {

        
            timer_save = 0f;

            SaveGame("profile", "save");

            
           
        }

        if(timer_timestamp >= 1){
            timer_timestamp = 0f;
            savedStats.timestamp_seconds ++;

        }

    }

    public void SaveGame(String profile, String save){
        loader.SaveData(profile, save);
    }

        

       



}
