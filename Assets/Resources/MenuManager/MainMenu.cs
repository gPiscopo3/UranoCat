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
    [SerializeField] private GameObject newGameCanvas;
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private GameObject LoadGameCanvas;
    [SerializeField] private GameObject LoadScreenCanvas;
    [SerializeField] private GameObject ProfileInput;
    [SerializeField] private TMP_Dropdown DropDown;
    [SerializeField] private GameObject contentPanel;
    public GameObject buttonPrefab;
    [SerializeField] private string scene_name;
    [SerializeField] Image _loadingBar;

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
    public void NewGame(){
        MainCanvas.SetActive(false);
        newGameCanvas.SetActive(true);
    }
    public void StartNewGame()
    {
        string profile_name = ProfileInput.GetComponent<TMP_InputField>().text;
        Profile profile = new Profile()
        {
            name = profile_name,
            last_save = null,
            dateTime = DateTime.Now
        };

        GameLoader.loaded_profile = profile.name;
        GameLoader.loaded_save = null;

        System.IO.Directory.CreateDirectory(path + profile.name);
        
 
        profiles.Add(profile);
        XMLHelper.SaveToXml<List<Profile>>(profiles, path + "profiles.xml");
        
        List<SaveInfo> saveInfos = new List<SaveInfo>();
        XMLHelper.SaveToXml<List<SaveInfo>>(saveInfos, path + profile.name + "/saves.xml");

        newGameCanvas.SetActive(false);
        LoadScreenCanvas.SetActive(true);

        StartCoroutine(LoadNextLevel());

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
        GameLoader.loaded_profile = profile_name;
        DirectoryInfo[] infos = new DirectoryInfo(path + "/" + profile_name).GetDirectories();

        createScrollView(infos);

        /*
        foreach (DirectoryInfo info in infos)
        { 
            
            // Instantiate (clone) the prefab    
            GameObject button = (GameObject)Instantiate(buttonPrefab);


            button.transform.position = contentPanel.transform.position;
            button.GetComponent<RectTransform>().SetParent(contentPanel.transform);
            button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 10, 100);
            button.layer = 5;
            

           button.GetComponentInChildren<TMP_Text>().text = info.Name;
            
            Debug.Log("istanziato bottone: "+ button.name);

            /*
            UnityEngine.UI.Button buttonToInstantiate = Button;
            buttonToInstantiate.GetComponentInChildren<TMP_Text>().text = info.Name;
            Instantiate(buttonToInstantiate, new Vector3(0,y,0), Quaternion.identity);
            y += delta;
            
        }

    */

        /*
        DirectoryInfo info = new DirectoryInfo(path).GetDirectories()
                       .OrderByDescending(d => d.LastWriteTimeUtc).First();

        GameLoader.loaded_profile = Path.GetFileName(info.FullName);
        GameLoader.loaded_save = "save";
        SceneManager.LoadScene("TestScene1");
        */
    }

    /*
    public void GenerateMissionItemUI()
    {
        int i = 0;

        //contentPanel.GetComponent<RectTransform>().sizeDelta = Vector2.up * (itemHeight + itemSpacing) * missions.Count;

        foreach (Mission mission in this.missions.Where(x => x.MissionState == MissionState.ATTIVO || x.MissionState == MissionState.COMPLETATO))
        {

            MissionItemUI missionItemUI = Instantiate(ItemPrefab, contentPanel.transform).GetComponent<MissionItemUI>();
            missionItemUI.gameObject.SetActive(true);

            Debug.Log("spacing: " + Vector2.down * i * (itemHeight + itemSpacing));
            missionItemUI.SetMissionPosition(Vector2.down * i * (itemHeight + itemSpacing));
            missionItemUI.setToggle(mission);
            missionItemUI.setMissionTag(mission);

            string requirements = "";
            foreach (ItemRequirement itemRequirement in mission.RequiredItems)
            {
                Item item = this.keyItems.Find(x => x.tag.Equals(itemRequirement.tagKeyItem));
                requirements = requirements + " " + $"{item.name} x{itemRequirement.Quantity}, ";
            }
            missionItemUI.setRequirements(requirements);

            //missionItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, diff, itemWidth);
            contentPanel.GetComponent<RectTransform>().sizeDelta = Vector2.up * (itemHeight + itemSpacing) * missions.Count;

            i++;


        }

    }
    */

    private void createScrollView(DirectoryInfo[] infos)
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


        foreach (DirectoryInfo info in infos)
        {
            GameObject button = (GameObject)Instantiate(buttonPrefab, contentPanel.transform);
            button.SetActive(true);
            button.GetComponent<RectTransform>().position = contentPanel.transform.GetChild(0).gameObject.transform.position + new Vector3(0,y,0);
            //button.transform.position = new Vector3(0, y, 0);
            //Debug.Log(button.transform.position);
            y -= delta;

            button.GetComponentInChildren<TMP_Text>().text = info.Name;
            Button realButton = button.GetComponentInChildren<Button>();
            realButton.onClick.AddListener(() => SaveSelection(info.Name));

            button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, delta*i, 80);
            contentPanel.GetComponent<RectTransform>().sizeDelta = Vector2.down * (y+(delta*i)) * infos.Count();
            button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 380, 200);
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

