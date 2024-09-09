using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

   

    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider enjoymentSlider;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text equippedText;

    Cat cat;
    Player player;


    
    void Start()
    {
        this.cat = FindObjectOfType<CatLoader>().cat;
        this.player = FindObjectOfType<PlayerLoader>().player;
        
    }
    

    void Update()
    {
        
        hungerSlider.value = cat.getStat(CatTag.SAZIETA).currentValue;
        enjoymentSlider.value = cat.getStat(CatTag.DIVERTIMENTO).currentValue;
        happinessSlider.value = cat.getStat(CatTag.FELICITA).currentValue;
        moneyText.SetText(player.money.ToString());
        if(player.equippedItem!=null){
            equippedText.SetText("Oggetto equipaggiato: " + player.equippedItem.item.name);
        }
        else{
            equippedText.SetText("");
        }


    }

   



}
