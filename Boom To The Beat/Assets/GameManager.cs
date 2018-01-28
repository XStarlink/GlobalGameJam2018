using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float bpm;
    public float counter;

    private bool go;

    private List<ActivatePad> waitingRoom = new List<ActivatePad>();

	// Use this for initialization
	void Start ()
	{
	    bpm = bpm / 60 * 4;
	    go = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (go == true)
	        go = false;
	    counter += Time.fixedDeltaTime;
	    if (counter > (1 / bpm) * 32)
	    {
	        foreach (var launcher in waitingRoom)
	        {
	            launcher.launch(bpm);
	        }
	        counter = 0;
            waitingRoom.Clear();
        }
	}

    public void addToWaitingRoom(ActivatePad pad)
    {
        waitingRoom.Add(pad);
    }

}
