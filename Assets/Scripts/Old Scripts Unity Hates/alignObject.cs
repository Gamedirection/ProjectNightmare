using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alignObject : MonoBehaviour {

    private Camera cam;

	// Use this for initialization
	void Start () {
        //GameObject mainCam = GameObject.Find("Main Camera");
        //cam = mainCam.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		//cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane));

        Vector3 position = new Vector3();
        cam = Camera.main;
        Event e = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = e.mousePosition.x;
        mousePos.y = cam.pixelHeight - e.mousePosition.y;

        position = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        Debug.Log(position.x);
    }
}
