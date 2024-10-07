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
    //PlacedObject placedObject;
    List<PlacedObjectStatus> statusList;

    GameLoader gameLoader;

    MissingItemManager missingItemManager;

    [SerializeField] List<String> requiredItemTags;
    [SerializeField] String recivedItemTag;

    Item receivedItem;
    List<ItemRequirement> requirements;

    void Awake(){
        
    }



    void Start()
    {
        
        missingItemManager = FindObjectOfType<MissingItemManager>();
        gameLoader = FindObjectOfType<GameLoader>();
        player = gameLoader.player;
        
        this.statusList = gameLoader.placedObjectsStatus;

        PlacedObjectStatus status = this.statusList.FirstOrDefault(x => x.name == gameObject.name);
        Debug.Log(status);

        if(status != null && status.obtained)
            gameObject.SetActive(false);

        try{
            receivedItem = gameLoader.GetItem(recivedItemTag);
            requirements = new List<ItemRequirement>();
            foreach(String tag in requiredItemTags){
                ItemRequirement requirement = requirements.FirstOrDefault(x => x.tag.Equals(tag));
                if(requirement==null)
                    requirements.Add(new ItemRequirement{item = gameLoader.GetItem(tag), quantity = 1, tag = tag});
                else
                    requirement.quantity++;        
            }
        }catch(Exception){gameObject.SetActive(false);}
                
    }

    void Update()
    {
        
       
    }

    public void Interact()
    {   

        bool isObtainable = true;
        
        Item missingItem = null;
        int missingQuantity = 0;

        if(requirements!=null){
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
            player.inventory.addItem(receivedItem);
            Debug.Log("ottenuto " + receivedItem.name);

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
