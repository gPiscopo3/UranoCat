using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleppingController : MonoBehaviour, InteractableObject
{
    private SavedStats savedStats;
    private DayManager dayManager;

    private void Start()
    {
        savedStats = FindObjectOfType<GameLoader>().savedStats;
        dayManager = FindObjectOfType<DayManager>();
    }
    
    public void Interact()
    {

        Debug.Log("Interacting with bed");

        if (dayManager.isInteractionAvailable(InteractionType.SLEEP) && dayManager.areInteractionsDone(InteractionType.VIDEO))
        {
            dayManager.consumeInteraction(InteractionType.SLEEP);
            
        }
    }

    
}
