using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class GameView : MonoBehaviour
{

    public Vector3 camDiff;

    private Vector3 initPos;
    private bool onPlay;

    private GameObject selectedLevel;

    private GameObject selectedBlock;
    private Color baseColor;

    // Use this for initialization
    void Start()
    {
        onPlay = false;
        initPos = transform.position;
        selectedBlock = null;
    }

    // Update is called once per frame
    void Update()
    {
        clickOnPad();
        resetCam();
        PlayOrReset();
        PutBlockOnPad();

        if (selectedBlock != null)
        {
            Renderer renderer = selectedBlock.GetComponent<Renderer>();


            float emission = Mathf.PingPong(Time.time * 2, 1.0f);

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            renderer.material.SetColor("_EmissionColor", finalColor);
        }
    }

    void PlayOrReset()
    {
        if (Input.GetKeyDown("space"))
        {
            selectedLevel.GetComponentInChildren<ActivatePad>().PlayLevel();
        }
    }

    void PutBlockOnPad()
    {
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "pad" && selectedBlock != null)
            {
                Debug.Log(selectedBlock.transform.position.z);
                Vector3 vect = new Vector3();
                vect.x = Mathf.Round(hitInfo.point.x);
                vect.y = Mathf.Round(hitInfo.point.y) - (0.59f / 2f);
                vect.z = 34f;
                selectedBlock.transform.position = vect;
            }
        }
    }

    void clickOnPad()
    {

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "pad")
                {
                    Debug.Log("rigth click");
                    selectedLevel = hitInfo.collider.gameObject.transform.parent.gameObject;
                    hitInfo.collider.gameObject.transform.parent.gameObject.GetComponentInChildren<ActivatePad>().PlayLevel();
                    onPlay = !onPlay;

                }
            }
        }
        if (Input.GetMouseButtonDown(0))
            {
            RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
                {
                    if (hitInfo.collider.gameObject.tag == "pad")
                    {
                        if (onPlay == false)
                        {
                            selectedLevel = hitInfo.collider.gameObject.transform.parent.gameObject;
                            Vector3 lvlPos = selectedLevel.transform.position;
                            camDiff.x = -hitInfo.collider.gameObject.transform.localScale.x / 2;

                            lvlPos -= camDiff;
                            transform.position = lvlPos;
                            onPlay = true;
                            hitInfo.collider.gameObject.transform.parent.gameObject
                                .GetComponentInChildren<ActivatePad>().ResetLevel();
                        }
                        else if (selectedBlock != null)
                        {
                            Renderer renderer = selectedBlock.GetComponent<Renderer>();
                            renderer.material.SetColor("_EmissionColor", baseColor);
                            selectedBlock.GetComponent<AudioSource>().Play();
                            selectedBlock = null;
                        }
                    }
                    else if (hitInfo.collider.gameObject.tag == "block")
                    {
                        Debug.Log("hit");
                        if (selectedBlock != null)
                        {
                            Renderer renderer = selectedBlock.GetComponent<Renderer>();
                            renderer.material.SetColor("_EmissionColor", baseColor);
                            selectedBlock.GetComponent<AudioSource>().Play();
                            selectedBlock = null;
                        }
                        else
                        {
                            selectedBlock = hitInfo.collider.gameObject;
                            Renderer renderer = selectedBlock.GetComponent<Renderer>();
                            baseColor = renderer.material.GetColor("_EmissionColor");
                        }
                    }
                }
            }
        }

    void resetCam()
        {
            if (Input.GetKeyDown("escape"))
            {
                onPlay = false;
                selectedBlock = null;
                selectedLevel.GetComponentInChildren<ActivatePad>().ResetLevel();
                transform.position = initPos;
            }
        }
    }