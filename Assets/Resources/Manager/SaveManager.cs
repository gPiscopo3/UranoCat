using UnityEngine;
using System;

public class SaveManager : MonoBehaviour{

    GameLoader loader;
    SavedStats savedStats;
    Rules rules;

    private float timer_save = 0f;
    private float timer_timestamp = 0f;
   

    void Start()
    {
        this.loader = FindObjectOfType<GameLoader>();
        savedStats = loader.savedStats;
        rules = loader.rules;
        
    }
    

    void Update()
    {
        
        timer_save += Time.deltaTime;
        
        timer_timestamp += Time.deltaTime;

        if(timer_timestamp >= 1){
            timer_timestamp = 0f;
            savedStats.timestamp_seconds ++;

        }

        if (timer_save > rules.autosave_time)
        {

            savedStats.autosave = (savedStats.autosave + 1)%rules.autosave_number;
            SaveGame("auto"+savedStats.autosave);
            
            timer_save = 0f;
            
        }
    }

    public void SaveGame(String save){
        loader.SaveData("save");
    }
}
