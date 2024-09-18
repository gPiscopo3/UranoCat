using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class MissionManager : MonoBehaviour
{

    Player player; 
    List<Mission> missions;
   

    void Start()
    {
        this.player = FindObjectOfType<SaveLoader>().player;
        this.missions = FindObjectOfType<SaveLoader>().missions;
   
    }

    public void CheckMission()
    {

        foreach(Mission mission in this.missions.Where(x => x.MissionState == MissionState.ATTIVO))
        {

            bool isCompletable = true;
            foreach(ItemRequirement item in mission.RequiredItems)
            {
                   
                int quantity = this.player.inventory.items.FindAll(obj => obj.EqualsByTag(item.tagKeyItem)).Count;
                if(quantity < item.Quantity)
                {
                    isCompletable = false;    
                } 
                   
            }
            if(isCompletable)
            {
                mission.MissionState = MissionState.COMPLETATO;

                //TODO rimozione affidata al gestore dell' inventario
                foreach (ItemRequirement item in mission.RequiredItems)
                {
                    InventoryItem itemToRemove = this.player.inventory.items.Find(obj => obj.EqualsByTag(item.tagKeyItem));
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        Debug.Log("Rimosso" + i + " " + item.Quantity);
                        this.player.inventory.useItem(itemToRemove);
                        itemToRemove = this.player.inventory.items.Find(obj => obj.EqualsByTag(item.tagKeyItem));
                    }
                  
                }
                   
            } 

        }

        UpdateMissions();

    }

    // Una volta che una missione è stata completata andiamo ad aggiornare lo stato delle missioni che non sono attive
    public void UpdateMissions()
    {
    
        foreach(Mission inactiveMission in this.missions.Where(x => x.MissionState == MissionState.NON_ATTIVO))
        {
            
            bool isActivable = true;
            foreach(string requirement in inactiveMission.RequiredMissions)
            {
                Mission toCheckMission = this.missions.Find(x => x.tag == requirement);
                if (toCheckMission.MissionState != MissionState.COMPLETATO)
                {
                    isActivable = false;           
                }
            }
            if(isActivable)
            {
                inactiveMission.MissionState = MissionState.ATTIVO;
            }
        }

         foreach(Mission m in this.missions)
        {
            Debug.Log($"{m.tag}, {m.MissionState} {DateTime.Now}");
            foreach(InventoryItem item in this.player.inventory.items)
            Debug.Log($"{item.item.tag},{item.item.name},{item.ID}, {DateTime.Now}");
        }

    }

}
