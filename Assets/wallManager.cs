using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallManager : MonoBehaviour {

    public bool roundActive;

    private GameObject selectedWall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkForWallSelect();
        checkForMovement();
    }

    private void checkForWallSelect ()
    {
        if (Input.GetMouseButtonDown(0) && !roundActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 999999999))
            {
                if (hit.collider.gameObject.tag == "wall")
                {
                    selectedWall = hit.collider.gameObject;
                }
            }
        }
    }

    private void checkForMovement ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { selectedWall = null; }

        if (Input.GetKeyDown(KeyCode.A) && selectedWall != null) {
            selectedWall.transform.Translate(Vector3.left);
        }
    }
}
