using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionItemUIManager: MonoBehaviour
{

    [Header ("Layout Settings")]
    [SerializeField] float itemSpacing = 35.5f;
    float itemWidth;
    float itemHeight;
    float diff;


    [Header("UI Elements")]
    [SerializeField] GameObject contentPanel;
    [SerializeField] GameObject ItemPrefab;

    List<Mission> missions;
    List<Item> keyItems;

    void Start()
    {   
        missions = FindObjectOfType<MissionLoader>().missions;
        keyItems = FindObjectOfType<ItemLoader>().items;
        keyItems = keyItems.FindAll(x => x is KeyItem);

        CreateMissionBoard();
        GenerateMissionItemUI();

    }

    private void CreateMissionBoard()
    { 

        itemWidth = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        diff = (contentPanel.GetComponent<RectTransform>().sizeDelta.y - contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y)/2;

    }

    private void GenerateMissionItemUI()
    {

        for(int j=1; j<contentPanel.transform.childCount; j++)
        {
        
            Destroy(contentPanel.transform.GetChild(j).gameObject);
           
        }
        
        contentPanel.transform.GetChild(0).gameObject.SetActive(false);
        int i = 0;

        foreach(Mission mission in this.missions)
        {

            MissionItemUI missionItemUI = Instantiate(ItemPrefab, contentPanel.transform).GetComponent<MissionItemUI>();
            missionItemUI.gameObject.SetActive(true);

            missionItemUI.SetMissionPosition(Vector2.down * i * (itemWidth + itemSpacing));
            missionItemUI.setToggle(mission);
            missionItemUI.setMissionTag(mission);

            string requirements = "";
            foreach(ItemRequirement itemRequirement in mission.RequiredItems)
            {
                Item item = this.keyItems.Find(x => x.tag.Equals(itemRequirement.tagKeyItem));
                requirements = requirements + " " + $"{item.name}, x{itemRequirement.Quantity}";
            }
            missionItemUI.setRequirements(requirements);

            missionItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, diff, itemHeight);
            contentPanel.GetComponent<RectTransform>().sizeDelta= Vector2.down * (itemWidth + itemSpacing) * keyItems.Count;
                
            i++; 
            Debug.Log(i);

        }

    }

}