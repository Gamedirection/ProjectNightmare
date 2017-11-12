using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    [Header("Spawner Settings")]
    public float spawnRate;         // Time between each mob spawned
    public int numberToSpawn;       // Total number of mobs to spawn

    [Space (5)]
    [Header("Mob to Spawn")]
    public GameObject mob;          // Mob to spawn

    private float timer;            // Internal timer for tracking time between mob spawns
    private GameObject gameManager; // Game manager reference for round tracking

	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called at start of scene
	void Start () {
        //Error logging 
		if (spawnRate <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Invalid spawnrate on " + gameObject.name); }
        if (numberToSpawn <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Invalid spawn count on " + gameObject.name); }
        if (mob == null) { Debug.LogError("DEVELOPER ERROR - Bad Variable - No object reference to spawn unit at spawner " + gameObject.name); }

        gameManager = GameObject.Find("GAMEMANAGER");

        //Set internal time for spawning
        timer = spawnRate;
	}

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Decriment timer relative to real time
		if (timer >= 0)                                                                                                         // Check if timer is above 0
        {
            timer = timer - Time.deltaTime;                                                                                         // Reduce timer in real time
        }
        //If the timer has run out then spawn a mob and decrease the total number to spawn
        else if (numberToSpawn > 0)                                                                                             // ELSE if the number to spawn is above 0
        {
            timer = spawnRate;                                                                                                      // Reset timer between spawns
            GameObject mobClone = Instantiate(mob, transform.position, transform.rotation);                                         // Create a mob
            gameManager.GetComponent<roundManager>().mobsAlive++;                                                                   // Increase total mobs alive by 1
            numberToSpawn--;                                                                                                        // Reduce number of mobs to spawn
        }

        //Check for all mobs being spawned
        if (numberToSpawn == 0)                                                                                                 // Check if number of mobs to spawn is at 0
        {
            gameManager.GetComponent<roundManager>().spawnersComplete++;                                                            // Inform GAMEMANAGER that this spawner is complete
            gameObject.SetActive(false);                                                                                            // Turn off spawner to prevent spawning to continue
        }
	}
}
