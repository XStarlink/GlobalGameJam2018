using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{

    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	   // Vector3 vect
        Vector3 vect = transform.position;
        vect.x = obj.transform.position.x;
        transform.position = vect;
	}


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("sound");

        if (other.gameObject.tag == "block")
        {
            Debug.Log("sound");
            other.gameObject.GetComponent<TriggerCube>().TriggerSound();
        }
    }
}
