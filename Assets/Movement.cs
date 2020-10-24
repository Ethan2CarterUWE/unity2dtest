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
        //cars = GetComponent<GameObject>();
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
        if (right && up)
        {
            cars.transform.eulerAngles = new Vector3(0, 0, 135);
            Debug.Log("pelaselord");

        }

        if (left && up)
        {
            cars.transform.eulerAngles = new Vector3(0, 0, -45);
            Debug.Log("pelaselord");

        }

        if (right)
        {
            if (pause == false)
            {
                //cars.transform.Rotate(0.0f, 0.0f, 90f);
                cars.transform.eulerAngles = new Vector3(0, 0, 90);

                pause = true;
            }
            //continuous rotates, need it to only do once
        }


        if (up)
        {
            if (pause == false)
            {
                //cars.transform.Rotate(0.0f, 0.0f, 90f);
                cars.transform.eulerAngles = new Vector3(0, 0, 0);

                pause = true;
            }
            //continuous rotates, need it to only do once
        }

        if (down)
        {
            if (pause == false)
            {
                //cars.transform.Rotate(0.0f, 0.0f, 90f);
                cars.transform.eulerAngles = new Vector3(0, 0, 180);

                pause = true;
            }
            //continuous rotates, need it to only do once
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
            Debug.Log("fuck");
        }
        else
        {
            left = false;
            pause = false;
        }
    }








    /* public float speed = 2f;

     Rigidbody2D rigidBody;

     void Awake()
     {
         rigidBody = GetComponent<Rigidbody2D>();
     }

     void FixedUpdate()
     {
         Vector3 input = Vector3.zero;
         input.x = Input.GetAxisRaw("Horizontal");
         input.y = Input.GetAxisRaw("Vertical");

         Vector3 direction = input.normalized;

         Vector3 movement = direction * speed * Time.fixedDeltaTime;

         rigidBody.MovePosition(transform.position + movement);
     }*/












    /*Rigidbody2D rb;

    [SerializeField]
    float accelerationPower = 5f;
    [SerializeField]
    float steeringPower = 5f;
    float steeringAmount, speed, direction;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        steeringAmount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * accelerationPower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

        rb.AddRelativeForce(Vector2.up * speed);

        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);

    }*/



    /* public float speedForce = 15f;
     public float torqueForce = -200f;
     public float driftFactorSticky = 0.9f;
     public float driftFactorSlippy = 1;
     public float maxStickyVelocity = 2.5f;
     public float minSlippyVelocity = 1.5f; // <--- Exercise for the viewer

     // Use this for initialization
     void Start()
     {

     }

     void Update()
     {
         // check for button up/down here, then set a bool that you will use in FixedUpdate
     }

     // Update is called once per frame
     void FixedUpdate()
     {


         Rigidbody2D rb = GetComponent<Rigidbody2D>();

         Debug.Log(RightVelocity().magnitude);

          float driftFactor = driftFactorSticky;
          if (RightVelocity().magnitude > maxStickyVelocity)
          {
              driftFactor = driftFactorSlippy;
          }

         rb.velocity = ForwardVelocity() + RightVelocity(); //* driftFactor;

         if (Input.GetButton("Accelerate"))
         {
             rb.AddForce(transform.up * speedForce);

             // Consider using rb.AddForceAtPosition to apply force twice, at the position
             // of the rear tires/tyres
         }
         if (Input.GetButton("Brakes"))
         {
             rb.AddForce(transform.up * -speedForce / 2f);

             // Consider using rb.AddForceAtPosition to apply force twice, at the position
             // of the rear tires/tyres
         }

         // If you are using positional wheels in your physics, then you probably
         // instead of adding angular momentum or torque, you'll instead want
         // to add left/right Force at the position of the two front tire/types
         // proportional to your current forward speed (you are converting some
         // forward speed into sideway force)
         float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 2);
         rb.angularVelocity = Input.GetAxis("Horizontal") * tf;



     }

     Vector2 ForwardVelocity()
     {
         return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
     }

     Vector2 RightVelocity()
     {
         return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
     }*/

}
