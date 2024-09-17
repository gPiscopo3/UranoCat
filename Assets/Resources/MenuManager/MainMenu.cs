using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private String mainMenu;
    public void NewGame(){

        SaveInfo.profile = "profile";
        SaveInfo.save = null;
        SceneManager.LoadScene(mainMenu);

    }

    public void Continue(){
        SaveInfo.profile = "profile";
        SaveInfo.save = "save";
        SceneManager.LoadScene(mainMenu);

    }
    
}
