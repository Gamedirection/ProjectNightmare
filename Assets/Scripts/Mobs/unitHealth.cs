using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitHealth : MonoBehaviour {

    public float maxHealth;         // Maximum health = set by developer

    public float currentHealth;    // Current health the unit has

    [HideInInspector]
    public float damageTaken;       // Damage to be applied this frame


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        currentHealth = maxHealth;                                                          // Set current health to max value
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        if (damageTaken > 0)                                                                // Check if any damage needs to be applied this frame
        {
            currentHealth = currentHealth - damageTaken;                                        // Reduce current health by damage value
            damageTaken = 0;                                                                    // Reset damage taken to 0
        }

        if (currentHealth <= 0)                                                             // Check we we have no health
        {
            GameObject.Find("GAMEMANAGER").GetComponent<roundManager>().mobsAlive--;            // Remove this mob from the active counter
            Destroy(this.gameObject);                                                           // Kill the mob
        }
    }
}
