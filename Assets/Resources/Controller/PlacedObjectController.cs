using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlacedObjectController : MonoBehaviour, InteractableObject
{

    Player player;
    PlacedObject placedObject;
    List<PlacedObjectStatus> statusList;

    GameLoader gameLoader;

    MissinigItemManager missingItemManager;

    void Awake(){
        
    }



    void Start()


    {
        missingItemManager = FindObjectOfType<MissinigItemManager>();
        gameLoader = FindObjectOfType<GameLoader>();
        player = gameLoader.player;
        placedObject = gameLoader.placedObjects.FirstOrDefault(x => x.objectName.Equals(gameObject.name));
        this.statusList = gameLoader.placedObjectsStatus;

        PlacedObjectStatus status = this.statusList.FirstOrDefault(x => x.name == gameObject.name);
        Debug.Log(status);

        if(status != null && status.obtained && placedObject != null)
            gameObject.SetActive(false);
                
        
    
    }

    void Update()
    {
        
       
    }

    public void Interact()
    {   

        bool isObtainable = true;
        
        Item missingItem = null;
        int missingQuantity = 0;

        if(placedObject.requirements!=null){
            List<ItemRequirement> requirements = placedObject.requirements;
            foreach(ItemRequirement requirement in requirements){
                Debug.Log(requirement.tag);
                int count = player.inventory.items.FindAll(obj => obj.tag.Equals(requirement.tag)).Count;
                if (count < requirement.quantity){
                    isObtainable = false;
                    missingItem = requirement.item;
                    missingQuantity = requirement.quantity - count;
                    break;
                }
            }
        }

        if(!isObtainable){
            //Debug.Log($"non puoi averlo perche ti mancano {missingQuantity} oggetti di tipo {missingItem.name}");
            missingItemManager.setTextAndStartTimer($"ti manca {missingQuantity} oggetto/i di tipo {missingItem.name}");
        }
        else{
            Item item = gameLoader.GetItem(placedObject.itemTag);


            player.inventory.addItem(item);
            Debug.Log("ottenuto " + item.name);

            statusList.Add(new PlacedObjectStatus{name = gameObject.name, obtained = true});

            gameObject.SetActive(false);
        }


    }

    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new System.NotImplementedException();
        return base.GetHashCode();
    }
    

}
