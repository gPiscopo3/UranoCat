using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame(){

        SaveLoader.loaded_profile = "profile";
        SaveLoader.loaded_save = null;
        SceneManager.LoadScene("SampleScene 1");

    }

    public void Continue(){
        SaveLoader.loaded_profile = "profile";
        SaveLoader.loaded_save = "save";
        SceneManager.LoadScene("SampleScene 1");

    }
    
}
