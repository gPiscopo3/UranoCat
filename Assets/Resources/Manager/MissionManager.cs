using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

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

    }

    // Una volta che una missione è stata completata andiamo ad aggiornare lo stato delle missioni che non sono attive
    public void UpdateMissions()
    {
        Mission nextMission = this.missions.FirstOrDefault(x => x.MissionState == MissionState.NON_ATTIVO);

        if(nextMission != null)
        {
            nextMission.MissionState = MissionState.ATTIVO;
        }

    }

    public void Interact()
    {
        CheckMission();
    }
}
