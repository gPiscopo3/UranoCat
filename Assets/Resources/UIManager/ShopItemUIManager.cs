using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShopItemUIManager : MonoBehaviour
{

    [Header ("Layout Settings")]

    [SerializeField] float itemSpacing = 35.5f;
    float itemWidth;
    float itemHeight;
    float diff;


    [Header("UI Elements")]
    [SerializeField] GameObject contentPanel;
    [SerializeField] GameObject shopItemPrefab;

    [SerializeField] Button catItemButton;
    [SerializeField] Button keyItemButton;


    List<ShopItem> shopItems;
    Player player;


    


    // Start is called before the first frame update
    void Start()
    {

        
        this.shopItems = FindObjectOfType<ItemLoader>().shopItems;
        
        this.player = FindObjectOfType<PlayerLoader>().player;
        CreateShopUI();
        

        keyItemButton.onClick.AddListener(FilteringKeyItem);
        catItemButton.onClick.AddListener(FilteringCatItem);
        FilteringCatItem();


    }

    public void CreateShopUI(){
        
        // recupero la larghezza e l'altezza dello shop item
        itemWidth = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        // recupero la differenza tra l'altezza del contentPanel e l'altezza dello shop item
        diff = (contentPanel.GetComponent<RectTransform>().sizeDelta.y - contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y)/2;
        Debug.Log("differenza " + diff);
        
    }



    public void GenerateShopItemUI(Type type){


        for(int j=1; j<contentPanel.transform.childCount; j++){
        
           Destroy(contentPanel.transform.GetChild(j).gameObject);
           
        }
        contentPanel.transform.GetChild(0).gameObject.SetActive(false);
        
        //contentPanel.transform.DetachChildren();
        

        int i = 0;
        
        foreach(ShopItem shopItem in shopItems)
        {
            if(shopItem.item.GetType().Equals(type)){
                
                ShopItemUI shopItemUI = Instantiate(shopItemPrefab, contentPanel.transform).GetComponent<ShopItemUI>();
                shopItemUI.gameObject.SetActive(true);

                shopItemUI.GetComponent<Image>().enabled = true;


                shopItemUI.SetShopItemPosition(Vector2.right * i * (itemWidth + itemSpacing));

                shopItemUI.setTag(shopItem.Tag);
                shopItemUI.SetShopItemName(shopItem.item.name);
                shopItemUI.SetShopItemDescription(shopItem.item.descrizione);
                if(shopItem.MinLevelRequired > player.level)
                    shopItemUI.SetShopItemLevelNotEoungh(shopItem.MinLevelRequired);
                shopItemUI.SetShopItemPrice(shopItem.Price);
                shopItemUI.SetShopItemImage(shopItem.item.imagePath);

                
                
                //shopItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, diff, itemHeight);
                
                
                shopItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, diff, itemHeight);
                contentPanel.GetComponent<RectTransform>().sizeDelta= Vector2.right * (itemWidth + itemSpacing) * shopItems.Count;
                
                i++; 
            }
            
        }
        
        

    }


    public void FilteringKeyItem(){
        GenerateShopItemUI(typeof(KeyItem));

    }
    
    public void FilteringCatItem(){
        GenerateShopItemUI(typeof(CatItem));

    }
    



}
