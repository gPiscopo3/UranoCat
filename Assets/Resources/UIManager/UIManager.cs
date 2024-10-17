using System.Linq;
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
    [SerializeField] private Image equippedItemImage;
    Cat cat;
    Player player;
    Rules rules;
    
    void Start()
    {
        this.cat = FindObjectOfType<GameLoader>().cat;
        this.player = FindObjectOfType<GameLoader>().player;
        this.rules = FindObjectOfType<GameLoader>().rules;
        equippedItemImage.enabled = false;
        equippedText.enabled = false;
    }
    

    void Update()
    {
        
        hungerSlider.value = cat.getStat(CatTag.SAZIETA).currentValue;
        enjoymentSlider.value = cat.getStat(CatTag.DIVERTIMENTO).currentValue;
        happinessSlider.value = cat.getStat(CatTag.FELICITA).currentValue;

        experienceSlider.value = getExperiencePercentage();

        levelText.SetText(player.level.ToString());
        moneyText.SetText(player.money.ToString());

        try{
            if(player.equippedItem!=null){

                if(player.equippedItem.isUsable()){
                    
                    Sprite sprite = Resources.Load("Images/" + player.equippedItem.item.imagePath, typeof(Sprite)) as Sprite;
                    equippedItemImage.sprite = sprite;
                    equippedItemImage.enabled = true;
                    
                    if(player.equippedItem.item.durability == 0){
                        equippedText.SetText("\u221E");
                    } else {
                        equippedText.SetText((player.equippedItem.item.durability - player.equippedItem.numUses).ToString());
                    }
                    equippedText.enabled = true;
                }
            } else {
                equippedItemImage.enabled = false;
                equippedText.enabled = false;
            }
        } catch (UnassignedReferenceException e){
            Debug.LogWarning(e.Message);
        }
    }

    public float getExperiencePercentage(){
     
        Level lastLevel = rules.levels.FirstOrDefault(level => level.level == player.level);
        Level nextLevel = rules.levels.FirstOrDefault(level => level.level == player.level + 1);

        if(nextLevel == null)
            return 100f; 
        else
            return ((float)(player.experience - lastLevel.experience))/(nextLevel.experience - lastLevel.experience)*100;
    }

}
