using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame(){

        SaveInfo.profile = "profile";
        SaveInfo.save = null;
        SceneManager.LoadScene("SampleScene 1");

    }

    public void Continue(){
        SaveInfo.profile = "profile";
        SaveInfo.save = "save";
        SceneManager.LoadScene("SampleScene 1");

    }
    
}
