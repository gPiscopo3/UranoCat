using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using JetBrains.Annotations;
using UnityEditor;
using Unity.VisualScripting;

public class MissionManager : MonoBehaviour, InteractableObject
{

    Player player; 
    List<Mission> missions;

    [SerializeField] private GameObject VFX_MissionComplete;
    [SerializeField] private Transform VFX_SpawnPoint;

    private AudioSource audioSource;

    [SerializeField] private List<GameObject> spaceshipParts = new List<GameObject>();
    
    void Start()
    {
        this.player = FindObjectOfType<GameLoader>().player;
        this.missions = FindObjectOfType<GameLoader>().missions;
        this.audioSource = GetComponent<AudioSource>();

        foreach(Mission mission in this.missions.Where(x => x.enableSpaceshipModification))
        {

            if(mission.MissionState == MissionState.COMPLETATO){
                this.spaceshipParts.Find(obj => obj.name.Equals(mission.spaceshipPart)).SetActive(true);
            } else {
                this.spaceshipParts.Find(obj => obj.name.Equals(mission.spaceshipPart)).SetActive(false);
            }
        
        }
    }


    public void CheckMission()
    {
        Mission actualMission = this.missions.FirstOrDefault(x => x.MissionState == MissionState.ATTIVO);

        bool isCompletable = true;
        foreach(ItemRequirement item in actualMission.RequiredItems)
        {
            int quantity = this.player.inventory.items.FindAll(obj => obj.EqualsByTag(item.tag)).Count;    
            if(quantity < item.quantity)
            {
                isCompletable = false;    
            }            
        }
        
        Debug.Log($"Missione completata? {isCompletable}");
        if(isCompletable){
            actualMission.MissionState = MissionState.COMPLETATO;
            foreach (ItemRequirement item in actualMission.RequiredItems)
            {
                InventoryItem itemToRemove = this.player.inventory.items.Find(obj => obj.EqualsByTag(item.tag));
                for (int i = 0; i < item.quantity; i++)
                {
                    this.player.inventory.useItem(itemToRemove);
                    itemToRemove = this.player.inventory.items.Find(obj => obj.EqualsByTag(item.tag));
                }
                   
            }

            Instantiate(VFX_MissionComplete, VFX_SpawnPoint.position, VFX_SpawnPoint.rotation);
            audioSource.Play();

            if(actualMission.enableSpaceshipModification)
            {
                spaceshipParts.Find(obj => obj.name.Equals(actualMission.spaceshipPart)).SetActive(true);
            }

            UpdateMissions();
        }

        /*
        foreach(Mission mission in this.missions.Where(x => x.MissionState == MissionState.ATTIVO))
        {

            bool isCompletable = true;
            foreach(ItemRequirement item in mission.RequiredItems)
            {
                   
                int quantity = this.player.inventory.items.FindAll(obj => obj.EqualsByTag(item.tag)).Count;
                if(quantity < item.quantity)
                {
                    isCompletable = false;    
                } 
                   
            }
            Debug.Log($"Missione completata? {isCompletable}");
            if(isCompletable)
            {
                
                mission.MissionState = MissionState.COMPLETATO;
                foreach (ItemRequirement item in mission.RequiredItems)
                {
                    //TO DO: rimozione oggetti dall'inventario in base al criterio
                    InventoryItem itemToRemove = this.player.inventory.items.Find(obj => obj.EqualsByTag(item.tag));
                    for (int i = 0; i < item.quantity; i++)
                    {
                        this.player.inventory.useItem(itemToRemove);
                        itemToRemove = this.player.inventory.items.Find(obj => obj.EqualsByTag(item.tag));
                    }
                   
                }

                Instantiate(VFX_MissionComplete, VFX_SpawnPoint.position, Quaternion.identity);
                audioSource.Play();

                if(mission.enableSpaceshipModification)
                {
                    spaceshipParts.Find(obj => obj.name.Equals(mission.spaceshipPart)).SetActive(true);
                }
                
            }

        }
        */
    }

    // Una volta che una missione è stata completata andiamo ad aggiornare lo stato delle missioni che non sono attive
    public void UpdateMissions()
    {
        Mission nextMission = this.missions.FirstOrDefault(x => x.MissionState == MissionState.NON_ATTIVO);

        if(nextMission != null)
        {
            nextMission.MissionState = MissionState.ATTIVO;
        }
        
        /*foreach(Mission inactiveMission in this.missions.Where(x => x.MissionState == MissionState.NON_ATTIVO))
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

        */

        foreach(Mission m in this.missions)
        {
            Debug.Log($"{m.tag}, {m.MissionState} {DateTime.Now}");
            foreach(InventoryItem item in this.player.inventory.items)
            Debug.Log($"{item.item.tag},{item.item.name},{item.ID}, {DateTime.Now}");
        }

    }

    public void Interact()
    {
        CheckMission();
    }
}
