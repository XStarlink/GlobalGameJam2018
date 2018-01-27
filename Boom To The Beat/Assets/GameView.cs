using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{

    public Vector3 camDiff;

    private Vector3 initPos;

    private bool onPlay;

	// Use this for initialization
	void Start ()
	{
	    onPlay = false;
	    initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    clickOnPad();
        resetCam();
    }


    void clickOnPad()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Creating container for the raycast result
            RaycastHit hitInfo = new RaycastHit();
            //Making the raycast
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "pad" && onPlay == false)
                {
                    //Debug.Log("hitPad");
                    Vector3 lvlPos = hitInfo.collider.gameObject.transform.parent.gameObject.transform.position;
                    lvlPos -= camDiff;
                    transform.position = lvlPos;
                }
            }
        }
    }

    void resetCam()
    {
        if (Input.GetKeyDown("space"))
        {
            transform.position = initPos;
        }
    }
}
