using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{

      Transform transfor;
      Rigidbody2D body;
    public GameObject cars;

        float horizontal;
        float vertical;
        float moveLimiter = 0.7f;

    bool pause = false;
    bool up = true;
    bool down = false;
    bool right = false;
    bool left = false;
    float y;

        public float Speed = 10.0f;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
        y = transform.rotation.z;
        }

        void Update()
        {
            // Gives a value between -1 and 1
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        CarRotate();
        Rotat();

        }

    void FixedUpdate()
    {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            body.velocity = new Vector2(horizontal * Speed, vertical * Speed);
    }

    void CarRotate()
    {
        //This doesnt work which means car atm can only face 4 directions
        /*
        if (right && up)
        {
            cars.transform.eulerAngles = new Vector3(0, 0, 135);
            Debug.Log("pelaselord");

        }

        if (left && up)
        {
            cars.transform.eulerAngles = new Vector3(0, 0, -45);
            Debug.Log("pelaselord");

        }*/

        if (right)
        {
            if (pause == false)
            {
                cars.transform.eulerAngles = new Vector3(0, 0, 90);

                pause = true;
            }
        }


        if (up)
        {
            if (pause == false)
            {
                cars.transform.eulerAngles = new Vector3(0, 0, 0);

                pause = true;
            }
            //continuous rotates, need it to only do once
        }

        if (down)
        {
            if (pause == false)
            {
                cars.transform.eulerAngles = new Vector3(0, 0, 180);

                pause = true;
            }
        }

        if (left)
        {
            cars.transform.eulerAngles = new Vector3(0, 0, -90);

            if (pause == false)
            {
                pause = true;


            }
        }
    }

    void Rotat()
    {
       
  
        if (vertical == 1)
        {
            up = true;
        }
        else
        {
            up = false;
            pause = false;
        }

        if (vertical == -1)
        {
            down = true;
        }
        else
        {
            down = false;
            pause = false;
        }

        if (horizontal == 1)
        {
            right = true;

        }
        else
        {
            right = false;
            pause = false;
        }

       if (horizontal == -1)
        {
            left = true;
            
        }
        else
        {
            left = false;
            pause = false;
        }
    }



}
