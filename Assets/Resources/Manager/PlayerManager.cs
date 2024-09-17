using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{

    Cat cat;    
    Player player;

    private float timer = 0f;

    bool lockUpdate = false;


    void Start()
    {
        this.player = FindObjectOfType<SaveLoader>().player;
    }
    

    void Update()
    {
        
        

    }




}
