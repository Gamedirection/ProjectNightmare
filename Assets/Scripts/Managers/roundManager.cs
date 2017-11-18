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
    public GameObject winGameOver;
    public GameObject loseGameOver;
    [Space(5)]
    public string nextMap;                         // Next map to load once the player completes this one

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
        if (roundTimer <= 0) { Debug.LogError("DEVELOPER ERROR - Round Options - Timer has been selected but time is set to zero on " + gameObject.name); }
        if (spawnersParent.Length == 0) { Debug.LogError("DEVELOPER ERROR - Null Reference - No object reference for spawners parent object on " + gameObject.name); }
        if (numberOfRounds <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Number of round is invalid on " + gameObject.name); }
        if (winGameOver == null) { Debug.LogError("DEVELOPER ERROR - Null Reference - No object set for win screen on " + gameObject.name); }
        if (loseGameOver == null) { Debug.LogError("DEVELOPER ERROR - Null Reference - No object reference for lose screen on " + gameObject.name); }

        winGameOver.SetActive(false);

        currentRound = -1;                                                                                                                       // Start off with a delay before the first round

        for (int i = 0; i < spawnersParent.Length; i++)                                                                                         // Iterate through all the spawners 
        {
            spawnersParent[i].SetActive(false);                                                                                                     // Set the array element to false
        }
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Decriment time if timer is above 0
		if (roundTimer >= 0 && roundActive)                                                                                                     // Check if round timer is above 0
        {
            roundTimer = roundTimer - Time.deltaTime;                                                                                               // Reduce round timer in real time
        }
        else                                                                                                                                    // ELSE
        {
            roundActive = false;                                                                                                                    // Set the round to inactive
            spawnersParent[currentRound].SetActive(false);                                                                                          // Turn off current spawner
        }
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called from Canvas element to restart for next round
    public void startRound ()
    {
        if (currentRound < numberOfRounds)                                                                                                      // Check if we've hit the total number of rounds
        {
            roundActive = true;                                                                                                                     // Set round to active
            roundTimer = roundTime;                                                                                                                 // Reset round timer
            currentRound++;                                                                                                                         // Iterate to the next round
            spawnersParent[currentRound].SetActive(true);                                                                                           // Set the spawner for the next round to active
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