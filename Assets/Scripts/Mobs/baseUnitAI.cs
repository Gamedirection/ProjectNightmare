using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class baseUnitAI : MonoBehaviour {

    private GameObject mainBed;     // Main bed in scene for unit to path to
    private int counter;            // Frame counter for updating navmesh chacks
    private NavMeshAgent nav;       // Component reference for the nav mesh agent

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method runs at start of scene
	void Start () {
        mainBed = GameObject.Find("mainBed");                                                                   // Find the main bed reference for the unit when spawned 
        nav = GetComponent<NavMeshAgent>();                                                                     // Sets component reference for the nav agent 
        nav.SetDestination(mainBed.transform.position);                                                         // Starts the units destination at the bed 

        counter = 0;                                                                                            //Starts counter off at 0 - prevents possible bugs

        if (mainBed == null) { Debug.LogError("DEVELOPER ERROR - Object Reference - Main bed for scene not set"); }
	}

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method runs ever frame while active
    void Update () {
		if (counter > 30)                                                                                       // Check if the frame counter has gone above 30 frames
        {
            counter = 0;                                                                                            // Reset counter 
            nav.SetDestination(mainBed.transform.position);                                                         // Reset unit destination t account for any changes in the nav mesh
        }
	}
}
