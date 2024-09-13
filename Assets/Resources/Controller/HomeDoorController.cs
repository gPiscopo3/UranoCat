using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDoorController : MonoBehaviour, InteractableObject
{

    Animator doorAnimator; 
    bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        isOpen = false;
        doorAnimator.SetBool("isOpen", isOpen);
        
    }

    

    public void Interact()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen", isOpen);
        Debug.Log("Interacting with door");

        /*if(isOpen){
            isOpen = !isOpen;
            doorAnimator.SetBool("isOpen", isOpen); 
        }*/
    }
}
