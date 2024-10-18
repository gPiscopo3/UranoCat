using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummaryUIManager : MonoBehaviour
{
    [SerializeField] private Image playerImage;
    [SerializeField] private TMP_Text levelValue; 
    [SerializeField] private TMP_Text experienceValue;
    [SerializeField] private TMP_Text followersValue;
    [SerializeField] private TMP_Text moneyValue;

    [SerializeField] private Button shopButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button missionButton;
    [SerializeField] private Button videoButton;

    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject missionBoard;
    [SerializeField] private GameObject videoBoard;

    Player player;

    UIManager uiManager;
    
    void Start()
    {
        this.player = FindObjectOfType<GameLoader>().player;
        this.uiManager = FindObjectOfType<UIManager>();

        shopButton.onClick.AddListener(OpenShop);
        inventoryButton.onClick.AddListener(OpenInventory);
        missionButton.onClick.AddListener(OpenMissionBoard);
        videoButton.onClick.AddListener(OpenVideoBoard);

    }

    void OpenShop()
    {
        shop.SetActive(true);
    }

    void OpenInventory()
    {
        inventory.SetActive(true);
    }   

    void OpenMissionBoard()
    {
        missionBoard.SetActive(true);
    }

    void OpenVideoBoard()
    {
        videoBoard.SetActive(true);
    }

    void Update()
    {
        
        levelValue.SetText(player.level.ToString());
        experienceValue.SetText(((int)uiManager.getExperiencePercentage()).ToString() + " %");
        followersValue.SetText(player.followers.ToString());
        moneyValue.SetText(((int)player.money).ToString());

    }

}

