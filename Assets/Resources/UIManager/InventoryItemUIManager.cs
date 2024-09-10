using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUIManager : MonoBehaviour
{

    [Header ("Layout Settings")]

    [SerializeField] float itemSpacing = 20.5f;
    float itemWidth;
    float itemHeight;
    
    float diff;




    [Header("UI Elements")]
    [SerializeField] GameObject contentPanel;
    [SerializeField] GameObject inventoryItemPrefab;
    Inventory inventory;
    Player player;

    Sprite sprite1;

    Vector3 vector3;
    Quaternion qua;

    [SerializeField] GameObject inventoryPanel;
    bool inventory_active = false;
    bool inventory_active_before = false;


    



    // Start is called before the first frame update

     void Start()
    {

        //prova
        sprite1 = Resources.Load("UIManager/salmon", typeof(Sprite)) as Sprite;
        
        this.player = FindObjectOfType<PlayerLoader>().player;

        this.inventory = player.inventory;

        CreateInventoryUI();


    }
    public void CreateInventoryUI(){
        
      
        itemWidth = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        diff = (contentPanel.GetComponent<RectTransform>().sizeDelta.y - contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y)/2;
        Debug.Log("differenza " + diff);
        
    }



    public void GenerateInventoryItemUI(){



        for(int j=1; j<contentPanel.transform.childCount; j++){
        
           Destroy(contentPanel.transform.GetChild(j).gameObject);
           
        }
        contentPanel.transform.GetChild(0).gameObject.SetActive(false);
        
        //contentPanel.transform.DetachChildren();
        

        
        int i = 0;

        Dictionary<string, ItemGroup> itemsGroup = new Dictionary<string, ItemGroup>();
     

        foreach(InventoryItem item in inventory.items){
            if(itemsGroup.ContainsKey(item.item.tag)){
                ItemGroup itemGroup = itemsGroup[item.item.tag];
                itemGroup.totalUses+=item.numUses;
                itemGroup.quantity++;
                if(itemGroup.itemToUse.numUses < item.numUses)
                    itemGroup.itemToUse = item;
            }
            else{
                itemsGroup.Add(item.item.tag, new ItemGroup(){
                    itemToUse = item,
                    totalUses = item.numUses,
                    quantity = 1
                });
            }
            

        }



        foreach (ItemGroup group in itemsGroup.Values)
        {
            
            InventoryItemUI inventoryItemUI = Instantiate(inventoryItemPrefab, contentPanel.transform).GetComponent<InventoryItemUI>();
            inventoryItemUI.gameObject.SetActive(true);
            inventoryItemUI.GetComponent<Image>().enabled = true;

            Debug.Log("creat");


            inventoryItemUI.SetItemPosition(Vector2.right * i * (itemWidth + itemSpacing));
            //inventoryItemUI.SetItemPosition(new Vector2(i * (itemWidth + itemSpacing), 57));

            inventoryItemUI.setItem(group.itemToUse);
            inventoryItemUI.SetItemName(group.itemToUse.item.name);
            inventoryItemUI.SetItemDescription(group.itemToUse.item.descrizione);
            inventoryItemUI.SetItemQuantity(group.quantity);
            inventoryItemUI.SetRemainingUses(group.itemToUse.item.durability  - group.itemToUse.numUses, group.itemToUse.item.durability);
            inventoryItemUI.setUsable();
            inventoryItemUI.SetItemImage(sprite1);

            
            inventoryItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, diff, itemHeight);
            //inventoryItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, diff, itemHeight);

            contentPanel.GetComponent<RectTransform>().sizeDelta= Vector2.right * (itemWidth + itemSpacing) * itemsGroup.Count;

            i++;
        }
    }

    public void Update(){

        inventory_active_before = inventory_active;
        inventory_active = inventoryPanel.activeSelf;

        if(inventory_active && !inventory_active_before){
            GenerateInventoryItemUI();
        }
    }




        private class ItemGroup{

            public InventoryItem itemToUse;
            public int totalUses;
            public int quantity;

            public ItemGroup(){}
        }


        
        

    }
    
