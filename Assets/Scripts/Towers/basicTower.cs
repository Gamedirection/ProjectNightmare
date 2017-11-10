using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicTower : MonoBehaviour {

    public float attackRate;                // Rate in seconds at which the tower will attack - public facing for devs
    private float attackRateTracker;        // Rate in seconds at which the tower will attack - code modified

    //[Space 5]
    public GameObject attackTrigger;        // Object reference for the towers trigger
    public GameObject spawnPoint;           // Object reference for where the projectile is spawned

    public GameObject missilePrefab;        // Object reference for the missile to spawn

    private GameObject target;              // Target object for tower to attack
    private bool canAttack;                 // The cooldown has been reset

    public float updateSpeed;               // Performance Tool - Public facing for Devs
    private float updateTracker;            // Performance tool - actively tracks update speed for trigger checks

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method run at start of scene
    void Start () {
        if (attackTrigger == null) { Debug.LogError("DEVELOPER ERROR - Object Reference - Range trigger for " + gameObject.name + " is missing"); }
        if (spawnPoint == null) { Debug.LogError("DEVELOPER ERROR - Object Reference - Spawn point for " + gameObject.name + " is missing"); }
        if (missilePrefab == null) { Debug.LogError("DEVELOPER ERROR - Object Reference - Missile Object for " + gameObject.name + " is missing"); }

        updateTracker = updateSpeed;                                                                                    // Start updateTracker at desired speed
        attackRateTracker = attackRate;                                                                                 // Starts attackRateTracker at desired time
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method run every frame while parent object is active
    void Update () {
        if (updateTracker > 0) { updateTracker--; }                                                                     // Decriments the updateTracker every frame
        if (attackRateTracker > 0) { attackRateTracker = attackRateTracker - Time.deltaTime; }                          // Decreases the attackRateTracker in real time


        if (updateTracker <= 0)                                                                                         // Check cooldown ending for if we should check attackRange object
        {
            target = attackTrigger.GetComponent<towerRange>().target;                                                       // Save the target object in a local variable
        }
        if (attackRateTracker <= 0)                                                                                     // Check cooldown ending for if attack rate reset
        {
            canAttack = true;                                                                                               // Update boolean saying we have passed the time requirement between attacks
        }


        if (target != null && canAttack)                                                                                // Check if we have a target AND cooldown has ended
        {
            attackRateTracker = attackRate;                                                                                 // Reset attack rate cooldown
            GameObject missileClone = Instantiate(missilePrefab, spawnPoint.transform.position, transform.rotation);        // Spawn the missile prefab
            missileClone.GetComponent<missileCommand>().target = target;                                                    // Give the missile an object reference for the target    
        }
	}
}
