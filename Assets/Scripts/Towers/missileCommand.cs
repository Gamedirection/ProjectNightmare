using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileCommand : MonoBehaviour {

    public GameObject target;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        //Move to the target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}
}
