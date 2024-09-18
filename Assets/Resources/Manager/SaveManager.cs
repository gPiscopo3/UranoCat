using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class SaveManager : MonoBehaviour
{


    

    SaveLoader loader;

    private float timer = 0f;

    Profiles profiles;

   

    
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

            SaveGame("save");
            

            
            
           
        }

    }

    public void SaveGame(String save){
        loader.SaveData(save);
    }

        

       



}
