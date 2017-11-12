using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour {

    [Header("Set Up Options")]
    public float roundTime;
    [HideInInspector]
    public float mobsAlive;
    
    [Space (5)]
    [Header("Round Limits - Select One")]
    public bool useTimer;
    public bool userAlive;

    [Space (10)]
    [Header("Spawners in the Scene")]
    public GameObject[] spawners;
    private bool[] spawnComplete;
    private bool allComplete;

	////////////////////////////////////////////////////////////////////////////////////////////
    //Metho called on start of scene
	void Start () {
		if (useTimer == false && useTimer == false) { Debug.LogError("DEVELOPER ERROR - Round Options - No round end option selected on " + gameObject.name); }
        if (roundTime <= 0 && useTimer) { Debug.LogError("DEVELOPER ERROR - Round Options - Timer has been selected but time is set to zero on " + gameObject.name); }

        spawnComplete = new bool[spawners.Length];
	}

    ////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Decriment time if timer is above 0
		if (roundTime >= 0)
        {
            roundTime = roundTime - Time.deltaTime;
        }

        //Check that all spawners have finished spawning mobs
        allComplete = checkSpawnersStatus();
	}

    private bool checkSpawnersStatus ()
    {
        for (int i = 0; i < spawners.Length; i++)
        {

        }

        return true;
    }
}
