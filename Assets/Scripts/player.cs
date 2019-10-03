using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public int moveforwardspeed;
    public int movebackwardspeed;
   

    public int jumpforce;

    public Rigidbody rb;

    public bool isjumping = false;
    public bool canlook = false;

    public GameObject MainCamera;
    public float RotateSpeed;
    public bool isRotating = true;

    public Image scope;
    public bool scopeon;

    //   private TrailRenderer tr;

    //public Text scoreText;
    // public int score;

    //public bool isColliding;

    float startTime = 0f;
    float holdTime = 1.0f; // 1 second


    public GameObject scopecam;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scope.enabled = false;//turn off scope

        scopecam.SetActive(false);

       
    }

    // Update is called once per frame
    void Update()
    {
        //isColliding = false;

        //scoreText.text = score.ToString();//print score

        if (scopeon == false)
        {


            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * moveforwardspeed * Time.deltaTime);


            }

            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * movebackwardspeed * Time.deltaTime);


            }

            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * movebackwardspeed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * movebackwardspeed * Time.deltaTime);
            }




            if (Input.GetKeyDown(KeyCode.Space) && isjumping == false)//jump
            {
                rb.AddForce(transform.up * jumpforce);
                isjumping = true;


                SetRotate(this.gameObject, MainCamera);

            }

        }

        if (isRotating) //Check if your game object is currently rotating
            SetRotate(this.gameObject, MainCamera);

        if (Input.GetKey(KeyCode.E))
        {
            if (canlook == true)//touching cube
            {

                if (scopeon == false)//not already opened
                {


                    scope.enabled = true;

                    scopeon = true;

                    scopecam.SetActive(true); //go to scope camera
                }

                if (startTime + holdTime <= Time.time) //hold to exit
                {
                    scope.enabled = false;

                    scopeon = false;

                    scopecam.SetActive(false);
                }

            }


        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            startTime = Time.time;

            
        }


    }

    void SetRotate(GameObject toRotate, GameObject camera)
    {//rotate camera
        //You can call this function for any game object and any camera, just change the parameters when you call this function
        transform.rotation = Quaternion.Lerp(toRotate.transform.rotation, camera.transform.rotation, RotateSpeed * Time.deltaTime);
    }


    void OnCollisionEnter(Collision collision)
    {
        isjumping = false;

        if (collision.collider.name == "Cube")
        {
            canlook = true;
        }

       
    }


    void OnCollisionExit(Collision collision)
    {
       

        if (collision.collider.name == "Cube")
        {
            canlook = false;
        }

        
    }
    void OnTriggerEnter(Collider collision) 
    {
       // if (isColliding) return;
       // isColliding = true; //makes sure only triggers once

        //score += 1;

       // transform.localScale += new Vector3(0.7f, 0.7f, 0.7f);

       // movespeed += 10;
       // jumpforce += 50;

      //  Debug.Log("1");
    }

    



}
