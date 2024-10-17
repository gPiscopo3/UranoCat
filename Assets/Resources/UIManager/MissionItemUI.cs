using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionItemUI: MonoBehaviour
{
    [SerializeField] Image toggle;
    [SerializeField] TMP_Text missionName;

    [SerializeField] GameObject itemRequiredPanel;

    [SerializeField] GameObject itemPrefab;

    Mission mission; 

    PlacedObjectManager placedObjectManager;

    float itemHeight;
    float itemWidth;
    float diff;
    float itemSpacing2 = 150.5f;

    public void Start(){
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

    public void setRequirements(Mission mission, List<InventoryItem> inventoryItems){

        this.mission = mission;

        GenerateItemRequiredPanel(inventoryItems);

    } 
    public void CreateRequiredItemPanel(){
        
        // recupero la larghezza e l'altezza dello shop item
        itemWidth = itemRequiredPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = itemRequiredPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        // recupero la differenza tra l'altezza del contentPanel e l'altezza dello shop item
        diff = (itemRequiredPanel.GetComponent<RectTransform>().sizeDelta.y - itemRequiredPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y)/2;
        
    }

    public void GenerateItemRequiredPanel(List<InventoryItem> inventoryItems){

        placedObjectManager = FindObjectOfType<PlacedObjectManager>();

        for(int j=1; j<itemRequiredPanel.transform.childCount; j++){
        
           Destroy(itemRequiredPanel.transform.GetChild(j).gameObject);
           
        }
        itemRequiredPanel.transform.GetChild(0).gameObject.SetActive(false);

        int i = 0;
        foreach (ItemRequirement item in mission.RequiredItems)
        {

            ItemRequiredUI itemUI = Instantiate(itemPrefab, itemRequiredPanel.transform).GetComponent<ItemRequiredUI>();
            itemUI.gameObject.SetActive(true);
            itemUI.SetImage(item.item.imagePath);
            int quantity;
            List<InventoryItem> items = new List<InventoryItem>();
            List<string> objects = new List<string>();

            if (mission.MissionState == MissionState.ATTIVO){
                items = inventoryItems.FindAll(obj => obj.EqualsByTag(item.tag));
                
                quantity = items.Count;
                
                itemUI.SetQuantity(quantity.ToString() + "/" + item.quantity.ToString());
                
                objects = placedObjectManager.getObjects(item.tag);
                if (objects.Count > 0){
                    itemUI.SetSearchButton(item.tag);
                }
            }
           
            itemUI.SetPositionItem(Vector2.right * i * (itemWidth + itemSpacing2));
            itemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0.065f, 170f);
            i++;
        }
    }

}

