using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionLock : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
	}

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Touching");
    }
}
