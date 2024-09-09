using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpaceShip : MonoBehaviour, InteractableObject
{
    
    TestScript manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<TestScript>();
    }

    public void Interact()
    {
        manager.CheckMission();
    }

}
