using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;



public class MainMenu : MonoBehaviour
{
    

    [SerializeField] private GameObject LoadScreenCanvas;
    [SerializeField] private string scene_name;
    [SerializeField] Image _loadingBar;


    [Header("Main Canvas")]
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private TMP_Dropdown DropDown;

    [Header("New Game Canvas")]
    [SerializeField] private GameObject newGameCanvas;
    [SerializeField] private GameObject ProfileInput;
    [SerializeField] private Button startNewGameButton;
    [SerializeField] private Button backHomeButton2;
    [SerializeField] private TMP_Text errorText;

    [Header("Load Game Canvas")]
    [SerializeField] private GameObject LoadGameCanvas;
    
    [SerializeField] private GameObject contentPanel;
    public GameObject buttonPrefab;
    [SerializeField] private Button backHomeButton1;
    

    private string path = "Saves/";

    private List<Profile> profiles;


    public void Awake()
    {
        MainCanvas.SetActive(true);
        LoadGameCanvas.SetActive(false);
        newGameCanvas.SetActive(false);

        profiles = XMLHelper.LoadFromXml<List<Profile>>(path + "profiles.xml");
        List<string> profile_names = new List<string>();

        profiles = profiles.OrderByDescending(profile => profile.dateTime).ToList();

        foreach (Profile p in profiles)
        {
            profile_names.Add(p.name);
        }

        DropDown.AddOptions(profile_names);
        

    }

    public void Start(){
        continueButton.onClick.AddListener(Continue);
        newGameButton.onClick.AddListener(NewGame);
        loadGameButton.onClick.AddListener(LoadGame);
        startNewGameButton.onClick.AddListener(StartNewGame);

        backHomeButton1.onClick.AddListener(() => { 
            LoadGameCanvas.SetActive(false); 
            MainCanvas.SetActive(true); 
            });

        backHomeButton2.onClick.AddListener(() => { 
            newGameCanvas.SetActive(false); 
            MainCanvas.SetActive(true); 
            });

    }



    public void NewGame(){
        MainCanvas.SetActive(false);
        newGameCanvas.SetActive(true);
    }
    
    public void StartNewGame()
    {
        string profile_name = ProfileInput.GetComponent<TMP_InputField>().text;
        if (profile_name == "")
        {
            errorText.text = "Please enter a name";
        }
        else{
            errorText.text = "";
            Profile profile = new Profile()
            {
                name = profile_name,
                last_save = null,
                dateTime = DateTime.Now
            };

            SaveLoader.loaded_profile = profile.name;
            SaveLoader.loaded_save = null;

            System.IO.Directory.CreateDirectory(path + profile.name);
            
    
            profiles.Add(profile);
            XMLHelper.SaveToXml<List<Profile>>(profiles, path + "profiles.xml");
            
            List<SaveInfo> saveInfos = new List<SaveInfo>();
            XMLHelper.SaveToXml<List<SaveInfo>>(saveInfos, path + profile.name + "/saves.xml");

            newGameCanvas.SetActive(false);
            LoadScreenCanvas.SetActive(true);

            StartCoroutine(LoadNextLevel());
        }
    }

    public void Continue(){


       
        string profile_name = DropDown.options[DropDown.value].text;
        string last_save = profiles.Find(profile => profile.name.Equals(profile_name)).last_save;
        GameLoader.loaded_profile = profile_name;
        GameLoader.loaded_save = last_save;

        MainCanvas.SetActive(false);
        LoadScreenCanvas.SetActive(true);

        StartCoroutine(LoadNextLevel());


    }

    public void LoadGame()
    {

        MainCanvas.SetActive(false);
        LoadGameCanvas.SetActive(true);

        string profile_name = DropDown.options[DropDown.value].text;
        SaveLoader.loaded_profile = profile_name;
        List<SaveInfo> infos = XMLHelper.LoadFromXml<List<SaveInfo>>(path + profile_name + "/saves.xml");

        createScrollView(infos);

    }

    private void createScrollView(List<SaveInfo> infos)
    {
        for (int j = 1; j < contentPanel.transform.childCount; j++)
        {

            Destroy(contentPanel.transform.GetChild(j).gameObject);

        }

        contentPanel.transform.GetChild(0).gameObject.SetActive(false);
        

        //contentPanel.GetComponent<RectTransform>().sizeDelta = Vector2.up * (itemHeight + itemSpacing) * missions.Count;

        float y = 0;
        float delta = 80f;
        int i = 0;


        foreach (SaveInfo info in infos)
        {
           

            ButtonPanelUI buttonPan = Instantiate(buttonPrefab, contentPanel.transform).GetComponent<ButtonPanelUI>();
            buttonPan.gameObject.SetActive(true);
            
            buttonPan.GetComponent<RectTransform>().position = contentPanel.transform.GetChild(0).gameObject.transform.position + new Vector3(0,y,0);
            //button.transform.position = new Vector3(0, y, 0);
            //Debug.Log(button.transform.position);
            y -= delta;

            buttonPan.SetButtonText("Load");
            buttonPan.SetLastAccess(info.time.ToString("dd/MM/yyyy HH:mm"));
            buttonPan.SetHourPlayed(info.seconds/60 + " minutes");
            buttonPan.button.onClick.AddListener(() => SaveSelection(info.name));

            buttonPan.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, delta*i, 150);
            contentPanel.GetComponent<RectTransform>().sizeDelta = Vector2.down * (y+(delta*i)) * infos.Count();
            buttonPan.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 380, 200);
            i++;

        }

    }

    public void SaveSelection(string selection)
    {
        GameLoader.loaded_save = selection;
        LoadGameCanvas.SetActive(false);
        LoadScreenCanvas.SetActive(true);

        StartCoroutine(LoadNextLevel());

        //SceneManager.LoadScene("TestScene2");
    }

    IEnumerator LoadNextLevel()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync("MainScene");
        Debug.Log("loading " + GameLoader.loaded_profile + ": " + GameLoader.loaded_save);

        while(!loadLevel.isDone) {
            _loadingBar.fillAmount = Mathf.Clamp01(loadLevel.progress / .9f);
            yield return null;
        }
    }

}

