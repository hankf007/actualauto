using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Transform target;


   // Vector3 offsetVector;


    // Use this for initialization
    void Start()
    {
       // offsetVector = this.transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate camera with mouse
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


        //follow player
        Vector3 newpos = target.position;
        this.transform.position = newpos;

        // this.transform.position = Vector3.MoveTowards(this.transform.position, newpos, 0.01f); //smoother transform

       
        //smoother transform
    }
}