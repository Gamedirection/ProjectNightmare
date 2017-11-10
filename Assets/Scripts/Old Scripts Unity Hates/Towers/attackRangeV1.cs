using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackRangeV1 : MonoBehaviour {

    public GameObject enemyUnit;            // Object reference for the tower to attack

    /*
     * Created by Liam Baillie on July 29, 2017
     * 
     * Script is attached to the line of sight object under player towers to track when an enemy has entered 
     * the towers attack range. While an enemy is within attack range this script tracks the object reference 
     * for the unit and acts to provide that reference for the tower script attached to the parent. 
     */

    ///////////////////////////////////////////////////////////////////////
    //Start method run at the beginning of the scene
    private void Start()
    {
        enemyUnit = null;                                               // Starts enemy unit as null to prevent potential bugs from Unity Engine reading null
    }

    ///////////////////////////////////////////////////////////////////////
    //onTriggerEnter method called when any object enters the trigger for the attached object
    //Method assigns object reference for unit to be attacked by tower
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("creep") && enemyUnit == null)             // Checks if object entering trigger is tagged as "creep" AND there is currently no object reference for attacking
        {
            enemyUnit = other.gameObject;                                   // Set object reference for enemy to attack
        }
    }

    ///////////////////////////////////////////////////////////////////////
    //onTriggerExit method called when any object leaves the trigger for the attached object
    //Method removes object reference for unit to be attacked when it leaves the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemyUnit)                              // 
        {
            enemyUnit = null;
        }
    }
}
