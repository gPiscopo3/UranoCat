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

    [SerializeField] private TMP_Text moneyText;


    void Start()
    {
        this.player = FindObjectOfType<PlayerLoader>().player;
    }
    

    void Update()
    {
        moneyText.SetText(player.money.ToString());
        

    }




}
