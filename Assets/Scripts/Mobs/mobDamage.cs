using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobDamage : MonoBehaviour {

    public float attackDamage;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called at start of scene
    void Start () {
        //Error Logging
		if (attackDamage <= 0) { Debug.LogError("DEVELOPER ERROR - Bad Variable - Mob damage has not been set on " + gameObject.name); }
	}

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called when the local collider impacts with any other collider
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bed")                                                                                  // Check if the other collider is a bed
        {
            collision.gameObject.GetComponent<unitHealth>().damageTaken += attackDamage;                                            // Apply damage to bed unitHealth component
            GameObject.Find("GAMEMANAGER").GetComponent<roundManager>().mobsAlive--;                                                // Remove this mob from the active counter
            Destroy(this.gameObject);                                                                                               // Destory this object
        }
    }
}
