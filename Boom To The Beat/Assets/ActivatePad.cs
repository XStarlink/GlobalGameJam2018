using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePad : MonoBehaviour
{
    private bool isPlayed;
    public float Bpm;

    private float levelSpeed;

	// Use this for initialization
	void Start ()
	{
	    isPlayed = false;
        levelSpeed = Bpm / 60 * 4;// * 32;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ResetLevel()
    {

        isPlayed = !isPlayed;
        CharacterController controller = GetComponentInChildren<CharacterController>();

        if (isPlayed == true)
        {
            controller.speed = levelSpeed;
        }
        else
        {
            
           // Debug.Log("reset2");
           //controller.speed = 0;
           //controller.ResetPos();
        }
    }
}
