using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roundManager : MonoBehaviour {

    [Header("Set Up Options")]
    public float roundTime;                     // Time the current round will run for
    public int numberOfRounds;                  // Total number of rounds for one scene

    [Space(5)]
    [Header("End of Game UI Objects")]
    public GameObject winGameOver;              // Canvas object for winning a game
    public GameObject loseGameOver;             // Canvas object for losing a game

    [Space(5)]
    [Header("Canvas Objects")]
    public GameObject startRoundButton;         // Object reference for round start button

    [Space(5)]
    [Header("Scene Visuals")]
    public GameObject daylight;                 // Light object for when the round is inactive
    public float nightLight;                    // Light intensity for while round is active

    [Space(5)]
    public string nextMap;                      // Next map to load once the player completes this one

    [Space(5)]
    [Header("Spawners in the Scene")]
    public GameObject[] spawnersParent;         // Parent object holding all spawners

    private bool roundActive;                   // Determines if the round is currently active
    private float roundTimer;                   // current time left in the round
    private int currentRound;                   // Current round the player is on

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Metho called on start of scene
	void Start () {
        //Error Logging
        if (roundTime <= 0) { Debug.LogError("DEVELOPER ERROR - Round Options - Timer has been selected but time is set to zero on " + gameObject.name); }
        if (spawnersParent.Length == 0) { Debug.LogError("DEVELOPER ERROR - Null Reference - No object reference for spawners parent object on " + gameObject.name); }
        if (spawnersParent.Length != numberOfRounds) { Debug.LogError("DEVELOPER ERROR - Bad Variable - There are not enough spawners for all rounds, check " + gameObject.name); }
        if (numberOfRounds <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Number of round is invalid on " + gameObject.name); }
        if (winGameOver == null) { Debug.LogError("DEVELOPER ERROR - Null Reference - No object set for win screen on " + gameObject.name); }
        if (startRoundButton == null) { Debug.LogError("DEVELOPER ERROR - Null Reference - No object reference for roundStartButton on  " + gameObject.name); }
        if (daylight == null) { Debug.LogError("DEVELOPER ERROR - Null Reference - No object reference for dayLight on " + gameObject.name); }
        if (nightLight <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Invalid value provided for night light intensity on " + gameObject.name); }

        winGameOver.SetActive(false);                                                                                                           // Start GameOver(win) to inactive
        
        startRoundButton.SetActive(true);                                                                                                       // Start startRoundButton to active

        roundActive = false;                                                                                                                    // Start round as inactive
        currentRound = -1;                                                                                                                      // Start off with a delay before the first round

        for (int i = 0; i < spawnersParent.Length; i++)                                                                                         // Iterate through all the spawners 
        {
            spawnersParent[i].SetActive(false);                                                                                                     // Set the array element to false
        }

        Time.timeScale = 0;                                                                                                                     // Start time as paused
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Decriment time if timer is above 0
		if (roundTimer >= 0 && roundActive)                                                                                                     // Check if round timer is above 0
        {
            roundTimer = roundTimer - Time.deltaTime;                                                                                               // Reduce round timer in real time
        }
        else if (roundActive)                                                                                                                                    // ELSE
        {
            endRound();                                                                                                                             // Update round variables for between rounds
        }
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method ends the round and updates variables
    private void endRound ()
    {
        roundActive = false;                                                                                                                    // Set the round to inactive
        spawnersParent[currentRound].SetActive(false);                                                                                          // Turn off current spawner
        GetComponent<wallManager>().roundActive = false;                                                                                        // Set the round active bool to false on the wall selection
        daylight.GetComponent<Light>().intensity = 1.0f;                                                                                        // Set light to full for "day"
        startRoundButton.SetActive(true);                                                                                                       // Turn on the "start new round" button
        GetComponent<mobManager>().killMobs();                                                                                                  // Kills all mobs in the scene
        Time.timeScale = 0f;                                                                                                                    // Pause game time
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called from Canvas element to restart for next round
    public void startRound ()
    {
        if (currentRound < numberOfRounds)                                                                                                      // Check if we've hit the total number of rounds
        {
            roundActive = true;                                                                                                                     // Set round to active
            GetComponent<wallManager>().roundActive = true;                                                                                         // Inform wall manager that round is active
            roundTimer = roundTime;                                                                                                                 // Reset round timer
            currentRound++;                                                                                                                         // Iterate to the next round
            spawnersParent[currentRound].SetActive(true);                                                                                           // Set the spawner for the next round to active
            daylight.GetComponent<Light>().intensity = nightLight;                                                                                  // Set light to "night"
            startRoundButton.SetActive(false);                                                                                                      // Turn off "start round" button
            Time.timeScale = 1f;                                                                                                                    // Allow time to continue
        }
        else                                                                                                                                    // ELSE
        {
            Time.timeScale = 0;                                                                                                                     // Stop game time
            winGameOver.SetActive(true);                                                                                                            // Set game win screen to active
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Loads next map if the player has won the current one
    public void loadNextMap ()
    {
        SceneManager.LoadScene(nextMap);                                                                                                        // Load the next scene in the list of player missions
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Loads the main menu if the player has lost or requested it from the pause menu
    public void returnToMenu ()
    {
        SceneManager.LoadScene("MainMenu");                                                                                                     // Load the main menu
    }
}