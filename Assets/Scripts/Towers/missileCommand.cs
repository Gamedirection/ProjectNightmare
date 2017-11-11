using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileCommand : MonoBehaviour {

    [HideInInspector]
    public GameObject target;               // Target object to move towards - informed by tower creating missile
    public float speed;                     // Speed at which the missile moves
    public float damage;                    // Damage dealt by the missile every attack
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame
	void Update () {
        //Move to the target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);    // Have the missile move towards the target object at a set speed
	}

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Method called when a collider enter the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mob")                                                                                  //Check for if the collider is a mob
        {
            float applyDamage = other.gameObject.GetComponent<unitHealth>().damageTaken;                                        // Grab what the current damage to be applied is
            applyDamage = applyDamage + damage;                                                                                 // Add the damage we want to do
            other.gameObject.GetComponent<unitHealth>().damageTaken = applyDamage;                                              // Set the new damage amount

            Destroy(this.gameObject);                                                                                           // Destroy the missile on impact
        }
    }
}
