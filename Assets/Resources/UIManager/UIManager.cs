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
    [SerializeField] private Slider experienceSlider;

    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text equippedText;

    Cat cat;
    Player player;


    
    void Start()
    {
        this.cat = FindObjectOfType<SaveLoader>().cat;
        this.player = FindObjectOfType<SaveLoader>().player;
        
    }
    

    void Update()
    {
        
        hungerSlider.value = cat.getStat(CatTag.SAZIETA).currentValue;
        enjoymentSlider.value = cat.getStat(CatTag.DIVERTIMENTO).currentValue;
        happinessSlider.value = cat.getStat(CatTag.FELICITA).currentValue;
        experienceSlider.value = player.experience;
        levelText.SetText(player.level.ToString());
        Debug.Log(player.level);
        moneyText.SetText(player.money.ToString());
        if(player.equippedItem!=null){
            equippedText.SetText("Oggetto equipaggiato: " + player.equippedItem.item.name);
        }
        else{
            equippedText.SetText("");
        }


    }

   



}
