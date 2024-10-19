using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{

    [SerializeField] Image imageItem;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text description;
    [SerializeField] Button priceButton;
    [SerializeField] TMP_Text price;
    [SerializeField] Image moneyImage;

    long priceValue;
    string tag;

    public void setTag(string tag){
        this.tag = tag;
    }

    public void SetShopItemPosition(Vector2 pos){
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetShopItemImage (string imagePath){

        Sprite sprite = Resources.Load(imagePath, typeof(Sprite)) as Sprite;
        
        imageItem.sprite = sprite;
        this.imageItem.GetComponent<Image>().enabled = true;

    }

    public void SetShopItemName(string name){

        this.itemName.text = name;
        this.itemName.enabled = true;
    }

    public void SetShopItemDescription(string description){

        this.description.text = description;
        this.description.enabled = true;
    }

    public void SetShopItemPrice(long price){

        this.priceValue = price;
        this.price.text = price.ToString();
        this.priceButton.GetComponent<Image>().enabled = true;
        Player player = FindObjectOfType<GameLoader>().player;
        if(player.money < price)
            SetNotAvailable();
        else
            this.priceButton.enabled = true;
        priceButton.onClick.AddListener(Acquista);
        
    }

    public void SetShopItemLevelNotEoungh(int level){
        SetNotAvailable();
        this.moneyImage.enabled = false;
        this.price.text = "Liv " + level.ToString();
    }

    private void Acquista(){
        
        long price = this.priceValue;
        Player player = FindObjectOfType<GameLoader>().player;
        Item item = FindAnyObjectByType<GameLoader>().GetItem(tag);
        if(player.money >= price && item!=null){
            player.money = player.money - price;
            player.inventory.addItem(item);
        }
        
    }

    private void SetNotAvailable(){
        this.price.color = Color.red;
        this.priceButton.image.color = Color.gray;
        this.priceButton.enabled = false;
    }

    void Update(){
        Player player = FindObjectOfType<GameLoader>().player;
        if(player.money < priceValue)
            SetNotAvailable();
    }

}
