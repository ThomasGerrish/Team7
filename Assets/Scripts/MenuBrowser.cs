using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBrowser : MonoBehaviour
{
    // Only needed for loading the main menu
    [SerializeField] private GameObject mainMenu;
    
    // Only needed for loading the index menu
    [SerializeField] private GameObject indexMenu;
    
    // Only needed for loading the settings menu
    [SerializeField] private GameObject settingsMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadArcade()
    {
        //SceneManager.LoadScene("Arcade Mode");
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadEndless()
    {
        //SceneManager.LoadScene("Endless Mode");
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadIndexMenu()
    {
        // Get Main Menu game object, set it to inactive
        transform.parent.parent.gameObject.SetActive(false);
        indexMenu.SetActive(true);
    }

    public void LoadMainMenu()
    {
        // Get whatever parent menu and deactivate it
        transform.parent.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadSettingsMenu()
    {
        // Get the Main Menu and deactivate it
        transform.parent.parent.gameObject.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
