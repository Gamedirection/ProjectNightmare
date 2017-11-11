using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public float spawnRate;
    public int numberToSpawn;

    [Space (10)]
    public GameObject mob;

    private float timer;

	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called at start of scene
	void Start () {
		if (spawnRate <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Invalid spawnrate on " + gameObject.name); }
        if (numberToSpawn <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Invalid spawn count on " + gameObject.name); }
        if (mob == null) { Debug.LogError("DEVELOPER ERROR - Bad Variable - No object reference to spawn unit at spawner " + gameObject.name); }

        timer = spawnRate;
	}

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Decriment timer relative to real time
		if (timer >= 0)
        {
            timer = timer - Time.deltaTime;
        }
        else
        {
            timer = spawnRate;
            GameObject mobClone = Instantiate(mob, transform.position, transform.rotation);
        }
	}
}
