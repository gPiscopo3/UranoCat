using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpaceShip : MonoBehaviour, InteractableObject
{
    
    MissionManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<MissionManager>();
    }

    public void Interact()
    {
        manager.CheckMission();
    }

}
