using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsationLigth : MonoBehaviour
{

    private Light light;
    private float time;
    private float initIntesity;

    public float pulseduration;

    public float pulseSpeed;



	// Use this for initialization
	void Start () {
	    light = GetComponent<Light>();
	    time = 0;
	    initIntesity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		Pulse(false);
	}

    public void Pulse(bool trigger)
    {
        if (trigger)
        {
            time += 0.001f;
        }
        if (time > pulseduration)
        {
            time = 0;
            light.intensity = 1.0f;

        }
        else if (time > 0)
        {
            time += Time.deltaTime;

            float floor = 1f;
            float ceiling = 2f;
            float emission = floor + Mathf.PingPong(Time.time * pulseduration * pulseSpeed, ceiling - floor);

           // float floor2 = light.range;
            //float ceiling2 = light.range;
            //float emission2 = floor2 + Mathf.PingPong(Time.time * pulseduration * pulseSpeed, ceiling2 - floor2);
            light.intensity = 1 * Mathf.LinearToGammaSpace(emission);

            //light.range = 1 * Mathf.LinearToGammaSpace(emission2) ;
        }
 
    }
}
 