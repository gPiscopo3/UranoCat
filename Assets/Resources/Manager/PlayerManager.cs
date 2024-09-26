using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{

    Cat cat;    
    Player player;
    Rules rules;

    private float timer = 0f;

    bool lockUpdate = false;

    public bool newLevel = false;

    void Start()
    {
        this.player = FindObjectOfType<SaveLoader>().player;
        this.rules = FindObjectOfType<AssetsLoader>().rules;
    }
    

    void Update()
    {
        
        Level nextLevel = rules.levels.FirstOrDefault(level => level.level == player.level + 1);
        if(nextLevel!= null && player.experience > nextLevel.experience){

            player.level++;
            player.pension = nextLevel.pension;
            player.money += nextLevel.reward;

            newLevel = true;
        }
        
        

    }




}
