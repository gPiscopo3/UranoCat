using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MissionItemUI: MonoBehaviour
{
    [SerializeField] Image toggle;
    [SerializeField] TMP_Text missionName;
    //[SerializeField] TMP_Text requirements;

    [SerializeField] GameObject itemRequiredPanel;

    [SerializeField] GameObject itemPrefab;


    float itemHeight;
    float itemWidth;
    float diff;
    float itemSpacing = 200.5f;


    public void Awake(){
        CreateRequiredItemPanel();
    }
    public void SetMissionPosition(Vector2 pos){

        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void setToggle(Mission mission){

        if (mission.MissionState == MissionState.COMPLETATO){
            toggle.enabled = true;
        } else {
            toggle.enabled = false;
        }
    }

    public void setMissionName(Mission mission){

        this.missionName.text = mission.name;
        this.missionName.enabled = true;

    } 

    public void setRequirements(List<ItemRequirement> requiredItems, List<InventoryItem> inventoryItems){

        

        GenerateItemRequiredPanel(requiredItems, inventoryItems);

    } 
    public void CreateRequiredItemPanel(){
        
        // recupero la larghezza e l'altezza dello shop item
        itemWidth = itemRequiredPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = itemRequiredPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        // recupero la differenza tra l'altezza del contentPanel e l'altezza dello shop item
        diff = (itemRequiredPanel.GetComponent<RectTransform>().sizeDelta.y - itemRequiredPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y)/2;
        
    }

    public void GenerateItemRequiredPanel(List<ItemRequirement> requiredItems, List<InventoryItem> inventoryItems){

        for(int j=1; j<itemRequiredPanel.transform.childCount; j++){
        
           Destroy(itemRequiredPanel.transform.GetChild(j).gameObject);
           
        }
        itemRequiredPanel.transform.GetChild(0).gameObject.SetActive(false);

        int i = 0;
        foreach (ItemRequirement item in requiredItems)
        {

            Debug.Log("item.tag: " + item.tag);
            ItemRequiredUI itemUI = Instantiate(itemPrefab, itemRequiredPanel.transform).GetComponent<ItemRequiredUI>();
            itemUI.gameObject.SetActive(true);
            itemUI.SetImage(item.item.imagePath);
            int quantity;
            List<InventoryItem> items = new List<InventoryItem>();
           // Debug.Log("plyer" + this.player.level);
            items = inventoryItems.FindAll(obj => obj.EqualsByTag(item.tag));
            
            quantity = items.Count;
            
            itemUI.SetSearchButton(item.tag);
          //  Debug.Log("quantity: " + quantity);
            itemUI.SetQuantity(quantity.ToString() + "/" + item.quantity.ToString());
            itemUI.SetPositionItem(Vector2.right * i * (itemWidth + itemSpacing));
            itemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0.065f, 170f);
            i++;
        }
    }

}

