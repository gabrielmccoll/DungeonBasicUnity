using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    Rigidbody2D rigidBodyComponent;
    //private bool isGrounded;
    [SerializeField] private Transform groudCheckTransform;
    [SerializeField] private LayerMask playerMask;
    private int superJumpsRemaining;

    private void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // it's not good to apply Physics in the Update
            //GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

    }

    // FixedUpdate is called once every Physics update
    // Unity Physics updates 100 a second by default
    // don't use it for keystroke as it can miss it during an update
    private void FixedUpdate()
    {
        //it will always run the horizontal input script this way
        rigidBodyComponent.velocity = new Vector3(horizontalInput, rigidBodyComponent.velocity.y, 0);
        // comparing sphere with a certain radius to see if the ground is touched
        // a transform object has position,rotation,scale
        // position could potentially bring back multiple values of all
        // overlapping spheres.  We need a bool for this.
        // So we're checking if the sphere has ANY overlap.
        // there will always be one overlap because the player has a collider
        // and collides with itself
        //  if (Physics.OverlapSphere(groudCheckTransform.position,0.1f).Length == 1)



        // now we make a new layer called Player to put the player on
        // a LayerMask called playerMask created. made Serialized. Then set to Everything except Player in Unity GUI
        if (Physics.OverlapSphere(groudCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return; // finishes the program and breaks out
        }

        if (jumpKeyWasPressed) //isGrounded
        {
            float jumpPower = 5;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            rigidBodyComponent.AddForce(Vector3.up * jumpPower);
            // if you don't reset the var then you'll do that aboe 100 times
            jumpKeyWasPressed = false;

        }
        // if we did this, then the speed up and down would be 0 and gravity would be less
        //GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput, 0,0);


    }

    //because this is attached to the Plater object, other refers to things that aren't the Player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }

    /*  This way caused problems when we were between two collidee
     *  collision object is Physics engine and contains info about the collision
    //we could remove the input collison object since we're not using it
    private void OnCollisionEnter(Collision collision) 
    {
        // you'de use the collision info with collision.whatever
        isGrounded = true;
    }

    private void OnCollisionExit()//removed)
    {
        isGrounded = false;
    }
    */
}