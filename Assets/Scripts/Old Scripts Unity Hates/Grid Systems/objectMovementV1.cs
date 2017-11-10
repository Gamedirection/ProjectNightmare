using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectMovementV1 : MonoBehaviour {

    private int moveCountVert;          // Current amount moved from starting position vertically 
    private int moveCountHori;          // Current amount moved from starting position horizontally 

    private int absMoveVert;            // Absolute value moved vertically - used for tracking total distance moved
    private int absMoveHori;            // Absolute value moved horizontally - used for tracking total distance moved
    private int totalMove;              // Total distance moved from starting position - includes vertical and horizontal movement

    [HideInInspector]
    public bool validPlacement;         // Boolean keepst track of if the current position for the object is valid
    [HideInInspector]
    public bool shouldCheck;            // Boolean determining when performance heavy math will be run - prevents unnecessary calculations from slowing down frame speed

    public int moveDistance;            // Distance object should move with every key press
    public int maxMoveDistance;         // Maximum distance the object is permitted to move

    public GameObject tooFarPrompt;     // Canvas prompt to inform DEVELOPER form when the object has moved too far - will be replaced for User interfacing later

    /*
     * Created by Liam Baillie on July 28, 2017
     * 
     * Script moves objects in the scene during gameplay a specified amount and for only a set number of times moved. Developers
     * can set the distance moved each key press as well as the total distance permitted to be moved by the player. Current controls 
     * use WASD and Arraw Keys for movement.
     * 
     * TEMP:
     * - Includes Canvas element that activates when the object has gone too fare
     *      -Will be replaced later for proper END USER experience
     *      
     * TO DO:
     * - Create system that determines if an object has entered another object. Sets validPlacement to false in this case.
     * - Create reset script that starts values at 0 for between rounds of the game (IE call the start script again)
     */

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Start method called at the beginning of the objects life
    //Checks for potential errors in variables to be set and writes to logs if needed
    //Starts variables at proper starting values
	void Start () {
		if (moveDistance <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable Value - Object movement distance not set"); }
        if (maxMoveDistance <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable Value - Object maximum move distance not set"); }
        if (tooFarPrompt == null) { Debug.LogError("DEVELOPER ERROR - Reference Not Set - tooFarPrompt for: " + this.gameObject.name); }

        moveCountVert = 0;                                                                                                      // Start vertical movement at 0 - bug prevention
        moveCountHori = 0;                                                                                                      // Start horizontal movement at 0 - bug prevention
        absMoveHori = 0;                                                                                                        // Starts absolute horizontal movement at 0 - bug prevention
        absMoveVert = 0;                                                                                                        // Starts absolute vertical movement at 0 - bug prevention

        shouldCheck = false;                                                                                                    // Starts shouldCheck at 0 - bug prevention
        validPlacement = false;                                                                                                 // Starts validPlacement at 0 - bug prevention
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Update method called every frame - acts as primary constructor for script
    //Method checks for user input, then checks for current distance from start position, and then assigns if the current position
    //is valid according to developer rules. Current rules are: Object is within a set distance of the starting point - object is 
    //not within another object
    void Update() { 
        //User Input
        checkForMovementInput();                                                                                                // Check for any user input

        //Run performance heavy math to check distance
        if (shouldCheck) { checkMoveDistance(); }                                                                               // If there has been user input, check the current distance for start position
        shouldCheck = false;                                                                                                    // Reset shouldCheck variable to prevent constant checks every frame
        
        //Check for moving too far
        if (totalMove > maxMoveDistance)                                                                                        // Check if total movement distance is greater than the maximum allowed distance
        {
            validPlacement = false;                                                                                                 // Set validPlacement to false - cannot place object at current position
        }                                                        
        else                                                                                                                    // ELSE
        {
            validPlacement = true;                                                                                                  // Set validPlacement to true - object can be place at current position
        }                                                                                     

        //Check for current position being valid
        if (validPlacement)                                                                                                     // Check if current position is valid
        {
            tooFarPrompt.SetActive(false);                                                                                          //Disable Canvas Prompt 
        }
        else                                                                                                                    // ELSE
        {
            tooFarPrompt.SetActive(true);                                                                                           // Enable Canvas Prompt
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method is called from Update method to check for any input from the user that causes object movement
    //Checks WASD and Arrow Key control input from user and moves object accordingly
    private void checkForMovementInput ()
    {
        //Check left movement
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))                                                 // Check for user input to move left
        {
            transform.position = new Vector3(transform.position.x - moveDistance, transform.position.y, transform.position.z);      // Set new position for object
            moveCountHori--;                                                                                                        // Decrement horizontal position 
            shouldCheck = true;                                                                                                     // Set distance check to true
        }
        //check right movement
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))                                                // Check for user input to move right
        {
            transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);      // Set new position for object
            moveCountHori++;                                                                                                        // Increment horizontal position
            shouldCheck = true;                                                                                                     // Set distance check to true
        }
        //Check upwards movement
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))                                                   // Check for user input to move upwards
        {   
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);      // Set new position for object
            moveCountVert++;                                                                                                        // Increment vertical position
            shouldCheck = true;                                                                                                     // Set distance check to true
        }
        //Check downwards movement
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))                                                 // Check for user input to move upwards
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveDistance);      // Set new position for object
            moveCountVert--;                                                                                                        // Decrement vertical position
            shouldCheck = true;                                                                                                     // Set distance check to true
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called from Update method to calculate the objects current distance from its starting point
    //Method uses performance heavy math, as such it is only called at specific times to prevent bogging down the system
    private void checkMoveDistance ()
    {
        absMoveHori = Mathf.Abs(moveCountHori);                                                                                 // Find the total distance moved on the X axis
        absMoveVert = Mathf.Abs(moveCountVert);                                                                                 // Find the total distance moved on the Y axis 
        totalMove = absMoveVert + absMoveHori;                                                                                  // Find total distance moved
    }
}