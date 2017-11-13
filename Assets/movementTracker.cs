using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTracker : MonoBehaviour {

    [HideInInspector]
    public int verticalCount;           // Tracks how far vertically the wall has moved this round
    [HideInInspector]
    public int horizontalCount;         // Tracks how far horizontally the wall has moved this round

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called at the start of the scene
    void Start () {
        verticalCount = 0;      // Start count at 0
        horizontalCount = 0;    // Start count at 0
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Lock position of wall to an integer
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
    }
}
