using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class CatManager : MonoBehaviour, InteractableObject
{

    Cat cat;

    Animator catAnimator;

    bool isRunning;

    void Start()
    {
        this.cat = new Cat();
        catAnimator = GetComponent<Animator>();

        isRunning = false;
    }

    void Update()
    {

    }
    
    public void Interact()
    {
        Debug.Log("Miao!");

        isRunning = !isRunning; 
        catAnimator.SetBool("isRunning", isRunning);
    }

}
