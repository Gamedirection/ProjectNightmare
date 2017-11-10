using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alignmentLock : MonoBehaviour {

    //Make sure position is always an real number
	void Update () {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
    }
}
