using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    

    PlayerLoader playerLoader;

    private float timer = 0f;

   

    
    void Start()
    {
        this.playerLoader = FindObjectOfType<PlayerLoader>();
        
    }
    

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10f)
        {

        
            timer = 0f;

            SaveGame();

            
           
        }

    }

    public void SaveGame(){

        playerLoader.SaveData();
        Debug.Log($"Gioco salvato");
       
    }

        

       



}
