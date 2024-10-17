using System.Linq;
using UnityEngine;


public class PlayerManager : MonoBehaviour{

    Player player;
    Rules rules;


    public bool newLevel = false;

    void Start()
    {
        this.player = FindObjectOfType<GameLoader>().player;
        this.rules = FindObjectOfType<GameLoader>().rules;
    }
    
    void Update()
    {
        
        Level nextLevel = rules.levels.FirstOrDefault(level => level.level == player.level + 1);
        if(nextLevel!= null && player.experience >  nextLevel.experience){

            player.level++;
            player.pension = nextLevel.pension;
            player.money += nextLevel.reward;

            newLevel = true;
        }
        
    }

}
