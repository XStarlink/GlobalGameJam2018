using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerCube : MonoBehaviour
{

    protected Light cubeLight;
    protected AudioSource sound;


    // Use this for initialization
    void Start()
    {

    }

    protected void startForSun()
    {
        cubeLight = GetComponent<Light>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void TriggerAction(CharacterController player);

    public void TriggerSound()
    {
        sound.Play();
    }
}
