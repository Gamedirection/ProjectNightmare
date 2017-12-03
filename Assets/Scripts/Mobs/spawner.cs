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
    private GameObject gameManager; // Game Manager for scene

	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called at start of scene
	void Start () {
        //Error logging 
		if (spawnRate <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Invalid spawnrate on " + gameObject.name); }
        if (numberToSpawn <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Invalid spawn count on " + gameObject.name); }
        if (mob == null) { Debug.LogError("DEVELOPER ERROR - Bad Variable - No object reference to spawn unit at spawner " + gameObject.name); }

        //Set internal time for spawning
        timer = spawnRate;

        gameManager = GameObject.Find("GAMEMANAGER");
	}

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Decriment timer relative to real time
		if (timer >= 0)                                                                                                         // Check if timer is above 0
        {
            timer = timer - Time.deltaTime;                                                                                         // Reduce timer in real time
            Debug.Log("Decreasing timer");
        }
        //If the timer has run out then spawn a mob and decrease the total number to spawn
        else if (numberToSpawn > 0)                                                                                             // ELSE if the number to spawn is above 0
        {
            Debug.Log("Spawning Mob");
            timer = spawnRate;                                                                                                      // Reset timer between spawns
            GameObject mobClone = Instantiate(mob, transform.position, transform.rotation);                                         // Create a mob
            numberToSpawn--;                                                                                                        // Reduce number of mobs to spawn
            gameManager.GetComponent<mobManager>().addMob(mobClone);                                                                // Add the spawned mob to the array of active mobs
        }

        //Check for all mobs being spawned
        if (numberToSpawn == 0)                                                                                                 // Check if number of mobs to spawn is at 0
        {
            gameObject.SetActive(false);                                                                                            // Turn off spawner to prevent spawning to continue
        }
	}
}
