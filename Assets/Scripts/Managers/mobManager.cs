using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobManager : MonoBehaviour {

    public int maxArraySize;                    // Size of array to be allocated to mob tracking

    [HideInInspector]
    public GameObject[] spawnedMobs;            // Array of Gameobjects that holds all active mobs in the scene
    [HideInInspector]
    public int index;                           // Current index for adding mobs to the array

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Start method runs at beginning of scene - initializes values
    void Start () {
        if (maxArraySize <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Array size too small on " + gameObject.name); }

        spawnedMobs = new GameObject[maxArraySize];                                                                                 // Set aside 1000 potential game objects for storing active mobs
        index = 0;                                                                                                                  // Start index at 0
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Called from an external script. Kills all active mobs in the scene
    public void killMobs ()
    {
        for (int i = 0; i < spawnedMobs.Length; i++)                                                                                // Iterate through all points in the array
        {
            if (spawnedMobs[i] != null)                                                                                                 // If the current point is not null
            {
                Destroy(spawnedMobs[i]);                                                                                                    // Kill the Gameobject
                spawnedMobs[i] = null;                                                                                                      // Set the current point in the array to null
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Called by external script. Adds a mob to the array using the Gameobject parameter
    public void addMob (GameObject mob)
    {
        spawnedMobs[index] = mob;                                                                                                   // Add a Gameobject reference for the mob to be added
        index++;                                                                                                                    // Increment the index
    }
}
