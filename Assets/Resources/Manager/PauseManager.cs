using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button desktopButton;
    [SerializeField] private Button continueButton;

    private GameLoader gameLoader;

    private PlayerController playerController;

    [SerializeField] protected GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        continueButton.onClick.AddListener(Continue);
        mainMenuButton.onClick.AddListener(mainMenu);
        desktopButton.onClick.AddListener(desktop);

        gameLoader = FindObjectOfType<GameLoader>();
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.setPauseFlag(false);
    }
    public void mainMenu()
    {
        gameLoader.SaveData("last");
        SceneManager.LoadScene("Main Menu");
    }
    public void desktop()
    {
        // da testare quando viene fatta la build
        gameLoader.SaveData("last");
        Application.Quit();
    }

}
