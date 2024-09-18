using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummaryUIManager : MonoBehaviour
{
    [SerializeField] private Image playerImage;
    [SerializeField] private TMP_Text levelValue; 
    [SerializeField] private TMP_Text experienceValue;
    [SerializeField] private TMP_Text followersValue;
    [SerializeField] private TMP_Text moneyValue;

    [SerializeField] private Button shopButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button missionButton;
    [SerializeField] private Button videoButton;

    Player player;
    
    void Start()
    {
        this.player = FindObjectOfType<SaveLoader>().player;


        shopButton.onClick.AddListener(() => {
            FindObjectOfType<ShopItemUIManager>().OpenShop();
        });

    }


    // Update is called once per frame
    void Update()
    {
        
        levelValue.SetText(player.level.ToString());
        experienceValue.SetText(player.experience.ToString());
        followersValue.SetText(player.followers.ToString());
        moneyValue.SetText(player.money.ToString());

    }
}
