using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{

    public float turnSpeed = 7;
    private Vector3 vel;
    private Vector3 acceleration;
    public float maxSpeed = 0.05f;
    public float maxReverse = 0.01f;

    void Start()
    {
        vel = new Vector3(0, 0, 0);
        acceleration = new Vector3(0, 0, 0);

    }

    void FixedUpdate()
    {       
        
        /*if (Input.GetKey(KeyCode.W))
        {
            float currentspeed = vel.magnitude;
            vel.Normalize();
            transform.Translate(0, acceleration.y, 0);
            if (acceleration.y <=0.30)
            {
                
                if (vel.magnitude <= maxSpeed)
                {
                    acceleration.y += 0.001f;
                }
            }
          
        }*/

        if (Input.GetKey(KeyCode.W))
        {
           
            transform.Translate(0, acceleration.y, 0);
            if (acceleration.y <= maxSpeed)
            {

                if (acceleration.y <= maxSpeed)
                {
                    acceleration.y += 0.001f;
                }
            }

        }

        if (Input.GetKey(KeyCode.Space))
        {
            float currentspeed = vel.magnitude;
            vel.Normalize();
            transform.Translate(0, acceleration.y, 0);

            if (acceleration.y >= maxReverse)
            {
                if (vel.magnitude >= -2 * maxSpeed)
                {
                    acceleration.y -= 0.005f;
                }
            }           
        }

        /*if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, acceleration.y, 0);

            if (acceleration.y >= maxReverse)
            {
                if (acceleration.y >= -2 * maxSpeed)
                {
                    acceleration.y -= 0.005f;
                }
            }
        }*/

        //rotate car
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -turnSpeed);
        }

        Moving();
        Debug.Log(acceleration.y);
    }

    void Moving()
    {
        //Function which checks player input and reduces speed if car has no acceleration .
        //
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space))
        {
            if(acceleration.y >=0)
            {
                transform.Translate(0, acceleration.y, 0);
                acceleration.y -= 0.0005f;
            }
            else if (acceleration.y <=0)
            {
                transform.Translate(0, acceleration.y, 0);
                acceleration.y += 0.0005f;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Function which checks how fast the car is going and depending on current speed, lower it when colliding with object
        //
        if (acceleration.y <= 0.1)
        {
            acceleration.y -= 0.03f;
            Debug.Log("slow");

        }
        else if (acceleration.y >= 0.2f)
        {
            acceleration.y -= 0.1f;
            Debug.Log("fast");
        }
        else
        {
            acceleration.y -= 0.06f;
            Debug.Log("middle");

        }
    }







}
