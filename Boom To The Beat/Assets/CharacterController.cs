using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed;
    public float lightSpeed;
    public float jumpForce;

    public float scaleChangeDuration;
    public float scaleChangeSpeed;

    public float jumpRange;
    private float currentJumpDist;

    private Rigidbody rb;
    private float     currentTime;
    private Vector3 initPos;
    private Light light;

    private float lastX;



    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        light = GetComponentInChildren<Light>();
        currentTime = 0;
        initPos = transform.position;
        speed = 0;
    }
	
	// Update is called once per frame

    void FixedUpdate()
    {
        Move();
        ControllLigth();
        ScaleDown(false);
        Jump(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jumpBlock")
        {
            Jump(true);
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();
        }
        else if (other.gameObject.tag == "dowsizeBlock")
        {
            ScaleDown(true);
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();
        }
        else if (other.gameObject.tag == "Finish")
        {
            //Vector3 vect = initPos;
            //vect.x += 1;
            //transform.position = vect;
            ResetPos();
            //Move();
            
        }

    }

    void Jump(bool jump)
    {
        if (currentJumpDist > 0)
        {
            Vector3 vect = transform.position;
            currentJumpDist -= transform.position.x - lastX;
            
            if (currentJumpDist > jumpRange / 2)
            {
                vect.y += jumpForce * (transform.position.x - lastX);
            }
            else
                vect.y -= jumpForce * (transform.position.x - lastX);
            if (vect.y < initPos.y)
                vect.y = initPos.y;
            transform.position = vect;
            lastX = transform.position.x;
        }
        if (jump == true)
        {
            currentJumpDist = jumpRange;
            lastX = transform.position.x;
        }
    }

    public void ResetPos()
    {
        transform.position = initPos;
        currentJumpDist = 0;
    }

    void ControllLigth()
    {
        if (Input.GetKey("space") && light.range < 200)
        {
            light.range *= lightSpeed;
        }
        else if (light.range > 10)
        {
            light.range -= lightSpeed * 2;
        }
    }

    void ScaleDown(bool triggerScaleDown)
    {
        if (currentTime > 0)
        {
            currentTime -= Time.fixedDeltaTime;
        }
        if (triggerScaleDown)
        {
            currentTime = scaleChangeDuration;
        }
        if (currentTime > 0 && transform.localScale.y > 0.5)
        {
            Vector3 vect = transform.localScale;
            vect.y -= scaleChangeSpeed;
            transform.localScale = vect;
            Vector3 vect2 = transform.position;
            vect2.y -= scaleChangeSpeed;
            transform.position = vect2;
        }
        else if (currentTime <= 0 && transform.localScale.y  < 1)
        {
            Vector3 vect = transform.localScale;
            vect.y += scaleChangeSpeed;
            transform.localScale = vect;
            Vector3 vect2 = transform.position;
            vect2.y += scaleChangeSpeed;
            transform.position = vect2;
        }
    }

    void Move()
    {
        Vector3 vect = transform.position;
        vect.x += speed * Time.fixedDeltaTime;
        transform.position = vect;
    }

}
