using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7;
    //Define the speed at which the object moves.
    Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    float horizontalInput;
    float countDown;
    SpriteRenderer sr;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        jumpTime = 0.2f;
        jumpForce = 10;
        
    }
    // Update is called once per frame
    void Update()
    {
        turnSprite();
        jump();

        getHurt();

        

    }

    private void getHurt() {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            sr.color = Color.white;
        }
    }


    private void turnSprite()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)//
        {
            gameObject.transform.eulerAngles = new Vector2(0, 0);
        }
        else if (horizontalInput < 0)
        {
            gameObject.transform.eulerAngles = new Vector2(0, 180);
        }

    }

    private void FixedUpdate()
    {
        moveHorizontal();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // this would need changed to something better. right now
        // it will effect any collision trigger
        countDown = 1;
        sr.color = Color.red;
 
    }

    private void moveHorizontal()
    {

        //Get the value of the Horizontal input axis.
        // I don't need to multiple by delta time because it's in fixed update.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

       // transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }

    private void jump()
    {
        // the physics part of this should really happen in FixedUpdate 
        //special jump that goes higher the longer you hold space
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //do the standard jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;

        }

        //is the space key is still held down while jumping, extend more.
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {

            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        {

        }
    }
}