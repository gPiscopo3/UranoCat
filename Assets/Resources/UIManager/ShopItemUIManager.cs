using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUIManager : MonoBehaviour
{

    [Header ("Layout Settings")]

    [SerializeField] float itemSpacing = 20.5f;
    float itemWidth;
    float itemHeight;



    [Header("UI Elements")]
    [SerializeField] GameObject contentPanel;
    [SerializeField] GameObject shopItemPrefab;


    List<ShopItem> shopItems;
    Player player;

    Sprite sprite1;

    Vector3 vector3;
    Quaternion qua;

    


    // Start is called before the first frame update
    void Start()
    {

        //prova
        sprite1 = Resources.Load("UIManager/salmon", typeof(Sprite)) as Sprite;
        
        this.shopItems = FindObjectOfType<ItemLoader>().shopItems;
        
        this.player = FindObjectOfType<PlayerLoader>().player;


        GenerateShopItemUI();


    }

    public void GenerateShopItemUI(){

        // recupero la larghezza e l'altezza dello shop item
        itemWidth = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        Debug.Log("alte " + itemWidth);

        itemHeight = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        
        Destroy(contentPanel.transform.GetChild(0).gameObject);
        //contentPanel.transform.DetachChildren();

        // recupero la differenza tra l'altezza del contentPanel e l'altezza dello shop item

        float diff = (contentPanel.GetComponent<RectTransform>().sizeDelta.y - contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y)/2;
        Debug.Log("differenza " + diff);

        
        int i = 0;
        
        foreach(ShopItem shopItem in shopItems)
        {
            
            ShopItemUI shopItemUI = Instantiate(shopItemPrefab, contentPanel.transform).GetComponent<ShopItemUI>();
            shopItemUI.GetComponent<Image>().enabled = true;


            shopItemUI.SetShopItemPosition(Vector2.right * i * (itemWidth + itemSpacing));
            //shopItemUI.SetShopItemPosition(new Vector2(i * (itemWidth + itemSpacing), 57));

            shopItemUI.setTag(shopItem.Tag);
            shopItemUI.SetShopItemName(shopItem.item.name);
            shopItemUI.SetShopItemDescription(shopItem.item.descrizione);
            if(shopItem.MinLevelRequired > player.level)
                shopItemUI.SetShopItemLevelNotEoungh(shopItem.MinLevelRequired);
            shopItemUI.SetShopItemPrice(shopItem.Price);
            shopItemUI.SetShopItemImage(sprite1);

            
            shopItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, diff, itemHeight);
            //shopItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, diff, itemHeight);

            contentPanel.GetComponent<RectTransform>().sizeDelta= Vector2.right * (itemWidth + itemSpacing) * shopItems.Count;

            i++;
        }


        
        

    }
    



}
