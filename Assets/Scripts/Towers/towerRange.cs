using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerRange : MonoBehaviour {

    [HideInInspector]
    public GameObject target;

    ///////////////////////////////////////////////////////////////////////////
    //Method called on start of scene
    void Start()
    {
        target = null;
    }

    ///////////////////////////////////////////////////////////////////////////
    //Method called when any object enters the trigger on this object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mob") && target == null)
        {
            target = other.gameObject;
        }
    }

    ///////////////////////////////////////////////////////////////////////////
    //Method called when any object leaves the trigger on this object
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            target = null;
        }
    }
}
