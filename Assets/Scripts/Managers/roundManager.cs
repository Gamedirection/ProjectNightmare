using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour {

    [Header("Set Up Options")]
    public float roundTime;                     // Time the current round will run for
    [HideInInspector]
    public int mobsAlive;                       // Current mobs alive in the scene
    
    [Space (5)]
    [Header("Round Limits - Select One")]
    public bool useTimer;                       // Boolean determining if the round ends after a set time
    public bool userAlive;                      // Boolean determining if killing all mobs will end the round

    [Space(5)]
    [Header("Spawners in the Scene")]
    public GameObject spawnersParent;           // Parent object holding all spawners
    [HideInInspector]
    public int spawnersComplete;                // Counter for number of spawners who have finished spawning
    private int totalSpawners;                  // Total number of spawners in the scene
    private bool allComplete;                   // Boolean determining if all spawners have finished spawning

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Metho called on start of scene
	void Start () {
        //Error Logging
		if (useTimer == false && useTimer == false) { Debug.LogError("DEVELOPER ERROR - Round Options - No round end option selected on " + gameObject.name); }
        if (roundTime <= 0 && useTimer) { Debug.LogError("DEVELOPER ERROR - Round Options - Timer has been selected but time is set to zero on " + gameObject.name); }
        if (spawnersParent == null) { Debug.LogError("DEVELOPER ERROR - Null Reference - No object reference for spawners parent object on " + gameObject.name); }

        totalSpawners = spawnersParent.transform.childCount;                                // Record number of spawners in scene
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Decriment time if timer is above 0
		if (roundTime >= 0)                                                                 // Check if round timer is above 0
        {
            roundTime = roundTime - Time.deltaTime;                                             // Reduce round timer in real time
        }

        if (spawnersComplete == totalSpawners) { allComplete = true; }                      // Set all spawners to being complete

        if (allComplete && mobsAlive == 0) { Debug.Log("Round Over"); }
	}
}
