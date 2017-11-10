using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {

    [Header("Main Menu - Menu References")]
    public GameObject mainMenu;                 // Object reference for Main Menu parent object 
    public GameObject settingsMenu;             // Object reference for Settings Menu parent object 
    public GameObject creditsMenu;              // Object reference for Credits Menu parent object

    /* Created by Liam Baillie - July 28, 2017
     * 
     * Script acts as primary game manager across all scenes in the game. Canvas actions and called are 
     * handled in this script as well as all game sub systems to be tracked during player
     * 
     * MAIN MENU MANAGEMENT
     * METHODS: changeScene / loadSettingsMenu / loadCreditsMenu / closeGame / loadMainMenu
     * Buttons in Canvas call methods in this section of the script to perform navigation actions between
     * different sections of the Main menu. Main menu acts as the hub for player options and actions before
     * initiating gameplay. 
     */

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Start Method - Runs at the start of the scene
    void Start()
    {
        if (mainMenu == null) { Debug.LogError("DEVELOPER ERROR - User Interface : Main Menu - Reference not set in Inspector"); }
        if (settingsMenu == null) { Debug.LogError("DEVELOPER ERROR - User Interface : Settings Menu - Reference not set in Inspector"); }
        if (creditsMenu == null) { Debug.LogError("DEVELOPER ERROR - User Interface : Credits Menu - Reference not set in Inspector"); }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Update Method - Runs every frame
    void Update()
    {
        
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Change Scene Method - Called from onButtonClick Event in UI - Main Menu
    public void changeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Load Settings Menu Method - Called from onButtonClick in UI - Main Menu
    //Sets Main Menu object to active and all other menus to inactive on the MAIN MENU scene
    public void loadSettingsMenu ()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Load Credits Menu Method - Called from onButtonClick in UI - Main Menu
    //Sets Credits Menu to active and all other menus to inactive on the MAIN MENU scene
    public void loadCreditsMenu ()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Close Game Method - Called from onButtonClick in UI - Main Menu
    //Quits game to desktop
    public void closeGame ()
    {
        Application.Quit();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Load Main Menu Method - Called from onButtonClick in UI - Main Menu
    //Sets Main Menu to active and all other menus to inactive on the MAIN MENU scene
    public void loadMainMenu ()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
}