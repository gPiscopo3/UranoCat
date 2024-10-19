using System;
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


    [SerializeField] GameObject inventoryPanel;
    bool inventory_active = false;
    bool inventory_active_before = false;

    Type type = typeof(CatItem);

    [SerializeField] Button keyItemButton;
    [SerializeField] Button catItemButton;


     void Start()
    {
        this.player = FindObjectOfType<GameLoader>().player;
        
        this.inventory = player.inventory;
        
        keyItemButton.onClick.AddListener(FilteringKeyItem);
        catItemButton.onClick.AddListener(FilteringCatItem);
      
        CreateInventoryUI();

    }
    public void CreateInventoryUI(){
        
      
        itemWidth = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        diff = (contentPanel.GetComponent<RectTransform>().sizeDelta.y - contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y)/2;
    }

    public void GenerateInventoryItemUI(Type type){

        for(int j=1; j<contentPanel.transform.childCount; j++){
        
           Destroy(contentPanel.transform.GetChild(j).gameObject);
           
        }
        contentPanel.transform.GetChild(0).gameObject.SetActive(false);

        int i = 0;

        Dictionary<string, ItemGroup> itemsGroup = new Dictionary<string, ItemGroup>();
     
        foreach(InventoryItem item in inventory.items){
            if(item.item != null && item.item.GetType() == type){
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
            

        }

        foreach (ItemGroup group in itemsGroup.Values)
        {
            
            InventoryItemUI inventoryItemUI = Instantiate(inventoryItemPrefab, contentPanel.transform).GetComponent<InventoryItemUI>();
            inventoryItemUI.gameObject.SetActive(true);
            inventoryItemUI.GetComponent<Image>().enabled = true;

            inventoryItemUI.SetItemPosition(Vector2.right * i * (itemWidth + itemSpacing));

            inventoryItemUI.setItem(group.itemToUse);
            inventoryItemUI.SetItemName(group.itemToUse.item.name);
            inventoryItemUI.SetItemDescription(group.itemToUse.item.descrizione);
            inventoryItemUI.SetItemQuantity(group.quantity);
            if(group.itemToUse.item.durability >0)
                inventoryItemUI.SetRemainingUses(group.itemToUse.item.durability  - group.itemToUse.numUses, group.itemToUse.item.durability);
            else
                inventoryItemUI.SetNotUsurable();
                
            if(group.itemToUse.item.GetType() == typeof(CatItem))
                inventoryItemUI.setUsable();

            inventoryItemUI.SetItemImage("Images/" + group.itemToUse.item.imagePath);

            
            inventoryItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, diff, itemHeight);

            contentPanel.GetComponent<RectTransform>().sizeDelta= Vector2.right * (itemWidth + itemSpacing) * itemsGroup.Count;

            i++;
        }
    }

    public void Update(){

        inventory_active_before = inventory_active;
        inventory_active = inventoryPanel.activeSelf;

        if(inventory_active && !inventory_active_before){
            GenerateInventoryItemUI(type);
        }
    }


    public void FilteringKeyItem(){
        GenerateInventoryItemUI(typeof(KeyItem));

    }
    
    public void FilteringCatItem(){
        GenerateInventoryItemUI(typeof(CatItem));

    }

    private class ItemGroup{

        public InventoryItem itemToUse;
        public int totalUses;
        public int quantity;

        public ItemGroup(){}
    }

}
    
