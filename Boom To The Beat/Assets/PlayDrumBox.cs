using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDrumBox : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
            //Creating container for the raycast result
            RaycastHit hitInfo = new RaycastHit();
	        //Making the raycast
	        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
	        {
	            if (hitInfo.collider.gameObject.tag == "pad")
	            {
	                hitInfo.collider.gameObject.transform.parent.gameObject.GetComponentInChildren<ActivatePad>().ResetLevel();

	            }
	        }
	    }
    }
}
