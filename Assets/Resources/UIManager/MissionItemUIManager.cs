using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionItemUIManager: MonoBehaviour
{

    [Header ("Layout Settings")]
    [SerializeField] float itemSpacing = 5.5f;
    float itemWidth;
    float itemHeight;
    float diff;


    [Header("UI Elements")]
    [SerializeField] GameObject contentPanel;
    [SerializeField] GameObject ItemPrefab;

    List<Mission> missions;
    List<Item> keyItems;
    public Player player;

    void Start()
    {   
        Debug.Log("MissionItemUIManager Start");
        this.missions = FindObjectOfType<GameLoader>().missions;
        keyItems = FindObjectOfType<GameLoader>().items;
        keyItems = keyItems.FindAll(x => x is KeyItem);
        this.player = FindObjectOfType<GameLoader>().player;
        
        CreateMissionBoard();
    }

    private void CreateMissionBoard()
    { 

        itemWidth = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        diff = (contentPanel.GetComponent<RectTransform>().sizeDelta.x - contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x)/2;

    }

    public void GenerateMissionItemUI()
    {

        for(int j=1; j<contentPanel.transform.childCount; j++)
        {
        
            Destroy(contentPanel.transform.GetChild(j).gameObject);
           
        }
        
        contentPanel.transform.GetChild(0).gameObject.SetActive(false);
        int i = 0;

        //contentPanel.GetComponent<RectTransform>().sizeDelta = Vector2.up * (itemHeight + itemSpacing) * missions.Count;

        foreach (Mission mission in this.missions.Where(x => x.MissionState == MissionState.ATTIVO || x.MissionState == MissionState.COMPLETATO))
        {
            
            MissionItemUI missionItemUI = Instantiate(ItemPrefab, contentPanel.transform).GetComponent<MissionItemUI>();
            missionItemUI.gameObject.SetActive(true);

            Debug.Log("spacing: " + Vector2.down * i * (itemHeight + itemSpacing));
            missionItemUI.SetMissionPosition(Vector2.down * i * (itemHeight + itemSpacing));
            missionItemUI.setToggle(mission);
            missionItemUI.setMissionName(mission);
            

            
            /*foreach(ItemRequirement itemRequirement in mission.RequiredItems)
            {
                
                Item item = this.keyItems.Find(x => x.tag.Equals(itemRequirement.tag));
                requirements = requirements + " " + $"{item.name} x{itemRequirement.quantity}, ";
            }*/

            Debug.Log("mission.RequiredItems: " + mission.RequiredItems.Count);
            missionItemUI.setRequirements(mission.RequiredItems, player.inventory.items);

            //missionItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, diff, itemWidth);
            contentPanel.GetComponent<RectTransform>().sizeDelta= Vector2.up * (itemHeight + itemSpacing) * missions.Count;
                
            i++; 
        
        }

    }

   void Update()
    {
        GenerateMissionItemUI();
    }

}