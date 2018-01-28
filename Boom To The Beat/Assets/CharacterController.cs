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

    private float lastX;
    public PulsationLigth pulseLight;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        currentTime = 0;
        initPos = transform.position;
        speed = 0;
    }
	
	// Update is called once per frame

    void FixedUpdate()
    {
        Move();
        ScaleDown(false);
         Jump(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "block")
        {
            pulseLight.Pulse(true);

            other.gameObject.GetComponent<TriggerCube>().TriggerAction(this);
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

    public void Jump(bool jump)
    {

     Vector3 vect = transform.position;
        if (transform.position.x - lastX > 0)
        {
            currentJumpDist -= transform.position.x - lastX;

            if (currentJumpDist > jumpRange / 2)
            {
                vect.y += jumpForce * (transform.position.x - lastX);
            }
            else
                vect.y -= jumpForce * (transform.position.x - lastX);
            if (vect.y < initPos.y && transform.localScale.y >= 1)
                vect.y = initPos.y;
            else if (vect.y < initPos.y)
            {
            vect.y = initPos.y - ((1 - transform.localScale.y) / 2);

            }
            //if ()
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


    public void ScaleDown(bool triggerScaleDown)
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
            vect2.y -= scaleChangeSpeed / 4;
            transform.position = vect2;
        }
        else if (currentTime <= 0 && transform.localScale.y  < 1)
        {
            Debug.Log("trap");
           Vector3 vect = transform.localScale;
            vect.y += scaleChangeSpeed;
            transform.localScale = vect;
            //Vector3 vect2 = transform.position;
            //vect2.y -= scaleChangeSpeed + 0.2f;
            //transform.position = vect2
        }
    }

    void Move()
    {
        Vector3 vect = transform.position;
        vect.x += speed * Time.fixedDeltaTime;
        transform.position = vect;
    }

}
