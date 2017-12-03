using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitHealth : MonoBehaviour {

    public float maxHealth;         // Maximum health = set by developer

    public float currentHealth;     // Current health the unit has

    public bool isBed;              // Is the object a bed

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

        if (currentHealth <= 0 && !isBed)                                                  // Check we we have no health AND we are not a bed
        {
            Destroy(this.gameObject);                                                           // Kill the mob
        } 
        if (currentHealth <= 0 && isBed)
        {
            Time.timeScale = 0;
            GameObject.Find("GAMEMANAGER").GetComponent<roundManager>().loseGameOver.SetActive(true);
        }
    }
}
