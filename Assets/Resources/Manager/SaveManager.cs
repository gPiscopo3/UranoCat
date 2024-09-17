using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class SaveManager : MonoBehaviour
{


    

    SaveLoader loader;

    private float timer = 0f;

   

    
    void Start()
    {
        this.loader = FindObjectOfType<SaveLoader>();
        
    }
    

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10f)
        {

        
            timer = 0f;

            SaveGame("profile", "save");

            
           
        }

    }

    public void SaveGame(String profile, String save){
        loader.SaveData(profile, save);
    }

        

       



}
