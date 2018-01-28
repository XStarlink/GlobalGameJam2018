using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Api;
using UnityEngine;

public class ActivatePad : MonoBehaviour
{
    private bool isPlayed;
    public float Bpm;

    private float levelSpeed;

    public Vector3 initBlockSetPos;

    public List<int> nbBocks;

    // Use this for initialization
    void Start ()
    {
	    isPlayed = false;
        levelSpeed = Bpm / 60 * 4;// * 32;
	}

    // Update is called once per frame
    void Update()
    {

    }

    void waitForBeat()
    {
        //GameManager manager = transform.GetComponentInParent<GameManager>();
        //while (manager.ShouldBegin() == false) ;
    }

    public void launch(float speed)
    {
        CharacterController controller = GetComponentInChildren<CharacterController>();
        controller.speed = speed;

    }

    public void PlayLevel()
    {
        isPlayed = !isPlayed;
        CharacterController controller = GetComponentInChildren<CharacterController>();

        if (isPlayed == true)
        {
            GameManager manager = transform.GetComponentInParent<GameManager>();
            manager.addToWaitingRoom(this);
        }
        else
        {
            
            // Debug.Log("reset2");
            controller.speed = 0;
            controller.ResetPos();
        }
    }

    public void quitLevel()
    {
        ResetLevel();

    }

    public void ResetLevel()
    {
        CharacterController controller = GetComponentInChildren<CharacterController>();


        controller.speed = 0;
        controller.ResetPos();
            //ResetSelectionBlock();
           //initSelectionBlock(); 
    }
}
