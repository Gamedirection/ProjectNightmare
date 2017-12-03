using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallManager : MonoBehaviour {

    [HideInInspector]
    public bool roundActive;                // Tracks if the round is currently active or is inbetween rounds

    private GameObject selectedWall;        // Object reference for the selected wall the player can move
    private int verticalMoveCount;          // Total vertical movement the wall has completed
    private int horizontalMoveCount;        // Total vertical movement the wall has completed

    [Header("Wall Options")]
    public int maxMoves;                    // Maximum number of times the wall can move in one round
    private bool canMoveLeft;               //
    private bool canMoveRight;
    private bool canMoveUp;
    private bool canMoveDown;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called at the start of the scene
    void Start () {
        //Error logging
		if (maxMoves < 1) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Max moves not set to a valid number on " + gameObject.name); }
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
    void Update () {
        //Check for the wall being within a valid movement distance, and set movement allowance accordingly
        if (Mathf.Abs(verticalMoveCount + horizontalMoveCount) < maxMoves)
        {
            canMoveDown = true;
            canMoveLeft = true;
            canMoveRight = true;
            canMoveUp = true;
        } else {
            canMoveDown = false;
            canMoveLeft = false;
            canMoveRight = false;
            canMoveUp = false;
            setValidDirections();
        }

        checkForWallSelect();
        checkForMovement();


    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Determines which directions are valid for the player to move given that we have are at the maximum movement distance for the round
    private void setValidDirections ()
    {
        if (verticalMoveCount > 0)
        {
            canMoveDown = true;
        }
        if (verticalMoveCount < 0)
        {
            canMoveUp = true;
        }
        if (horizontalMoveCount > 0)
        {
            canMoveLeft = true;
        }
        if (horizontalMoveCount < 0)
        {
            canMoveRight = true;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Checks for if the player has clicked on a wall in the game
    private void checkForWallSelect ()
    {
        if (Input.GetMouseButtonDown(0) && !roundActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 999999999))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "wall")
                {
                    Debug.Log("Hit the wall");
                    selectedWall = hit.collider.gameObject;
                    verticalMoveCount = selectedWall.GetComponent<movementTracker>().verticalCount;
                    horizontalMoveCount = selectedWall.GetComponent<movementTracker>().horizontalCount;
                }
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Moves a wall if it has been selected by the player
    private void checkForMovement ()
    {
        //Deselect the wall
        if (Input.GetKeyDown(KeyCode.Escape)) {                                                                                                     // Check for the player pressing "ESCAPE"
            selectedWall.GetComponent<movementTracker>().verticalCount = verticalMoveCount;                                                             // Update the number of times the wall has moved vertically
            selectedWall.GetComponent<movementTracker>().horizontalCount = horizontalMoveCount;                                                         // Update the number of times the wall has moved horizontally
            selectedWall = null;                                                                                                                        // Remove the object reference for the wall
        }

        if (Input.GetKeyDown(KeyCode.A) && selectedWall != null && canMoveLeft) {                                                                   // If the player presses A AND the wall is not null AND they can still move the wall
            selectedWall.transform.Translate(Vector3.left);                                                                                             // Move the wall to the left by 1
            horizontalMoveCount--;                                                                                                                      // Decriment the wall movement total (move left)
        }
        if (Input.GetKeyDown(KeyCode.D) && selectedWall != null && canMoveRight)                                                                    // If the player presses D AND the wall is not null AND they can still move the wall
        {
            selectedWall.transform.Translate(Vector3.left * -1);                                                                                        // Move the wall to the right by 1
            horizontalMoveCount++;                                                                                                                      // Increment the wall movement total (move right)
        }
        if (Input.GetKeyDown(KeyCode.W) && selectedWall != null && canMoveUp)                                                                       // If the player presses W AND the wall is not null AND they can still move the wall
        {
            selectedWall.transform.Translate(Vector3.forward);                                                                                               // Move the wall upwards by 1
            verticalMoveCount++;                                                                                                                        // Increment the wall movement total (move up)
        }
        if (Input.GetKeyDown(KeyCode.S) && selectedWall != null && canMoveDown)                                                                     // If the player pressed S AND the wall is not null AND they can still move the wall
        {
            selectedWall.transform.Translate(Vector3.forward * -1);                                                                                          // Move the downwards by 1
            verticalMoveCount--;                                                                                                                        // Decriment the wall movement total (move down)
        }
    }
}
