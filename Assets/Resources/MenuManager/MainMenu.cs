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

using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject newGameCanvas;
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private GameObject LoadGameCanvas;
    [SerializeField] private GameObject ProfileInput;
    [SerializeField] private TMP_Dropdown DropDown;
    [SerializeField] private string scene_name;

    private string path = "Saves/";

    private Profiles profiles;


    public void Awake()
    {
        MainCanvas.SetActive(true);
        LoadGameCanvas.SetActive(false);
        newGameCanvas.SetActive(false);

        profiles = XMLHelper.LoadFromXml<Profiles>(path + "profiles.xml");
        List<string> profile_names = new List<string>();

        foreach (Profiles.Profile p in profiles.profiles)
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
        Profiles.Profile profile = new Profiles.Profile()
        {
            name = profile_name,
            last_save = null
        };

        SaveLoader.loaded_profile = profile.name;
        SaveLoader.loaded_save = null;

        System.IO.Directory.CreateDirectory(path + profile.name);
        
 
        profiles.profiles.Add(profile);
        profiles.last_profile = profile; 
        XMLHelper.SaveToXml<Profiles>(profiles, path + "profiles.xml");
        
        List<SaveInfo> saveInfos = new List<SaveInfo>();
        XMLHelper.SaveToXml<List<SaveInfo>>(saveInfos, path + profile.name + "/saves.xml");


        SceneManager.LoadScene("TestScene1");
    }

    public void Continue(){


       
        SaveLoader.loaded_profile = profiles.last_profile.name;
        SaveLoader.loaded_save = profiles.last_profile.last_save;

        SceneManager.LoadScene("TestScene1");


    }

    public void LoadGame()
    {
        

        MainCanvas.SetActive(false);
        LoadGameCanvas.SetActive(true);

        DirectoryInfo info = new DirectoryInfo(path).GetDirectories()
                       .OrderByDescending(d => d.LastWriteTimeUtc).First();

        SaveLoader.loaded_profile = Path.GetFileName(info.FullName);
        SaveLoader.loaded_save = "save";
        SceneManager.LoadScene("TestScene1");

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
}
