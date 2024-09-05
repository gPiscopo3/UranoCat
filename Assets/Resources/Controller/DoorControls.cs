using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControls : MonoBehaviour, InteractableObject
{
    
    Animation doorAnimation; 
    BoxCollider doorCollider;
    bool isOpen;

    void Start(){
        doorAnimation = GetComponent<Animation>();
        doorCollider = GetComponent<BoxCollider>();
        isOpen = false;
    }

    public void Interact()
    {
        isOpen = !isOpen;

        if(!isOpen){
            doorAnimation.Play("Door_Close");
            doorCollider.isTrigger = false;
        }else{
            doorAnimation.Play("Door_Open");
            doorCollider.isTrigger = true;   
        }
        
    }

}
