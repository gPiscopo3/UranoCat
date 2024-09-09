using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class SaveManager : MonoBehaviour
{


    

    PlayerLoader playerLoader;
    CatLoader catLoader;

    private float timer = 0f;

   

    
    void Start()
    {
        this.playerLoader = FindObjectOfType<PlayerLoader>();
        this.catLoader = FindObjectOfType<CatLoader>();
        
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

        playerLoader.SaveData(profile, save);
        catLoader.SaveData(profile, save);

        Debug.Log($"Gioco salvato");
       
    }

        

       



}
