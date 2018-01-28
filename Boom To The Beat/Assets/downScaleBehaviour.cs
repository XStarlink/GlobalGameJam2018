using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downScaleBehaviour : TriggerCube
{

	// Use this for initialization
	void Start () {
		startForSun();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerAction(CharacterController player)
    {
        player.ScaleDown(true);
    }

}
