using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button desktopButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button CommandsButton;
    [SerializeField] private Button backButton;

    private GameLoader gameLoader;

    private PlayerController playerController;

    [SerializeField] protected GameObject pausePanel;
    [SerializeField] protected GameObject commandsPanel;

    

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        continueButton.onClick.AddListener(Continue);
        mainMenuButton.onClick.AddListener(mainMenu);
        desktopButton.onClick.AddListener(desktop);
        CommandsButton.onClick.AddListener(Commands);
        backButton.onClick.AddListener(() => commandsPanel.SetActive(false));

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

    public void Commands()
    {
        commandsPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

}