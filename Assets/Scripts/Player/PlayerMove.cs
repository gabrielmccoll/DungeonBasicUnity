using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)//
        {
            gameObject.transform.eulerAngles = new Vector2(0, 0);
        }
        else if(horizontalInput < 0)
        {
            gameObject.transform.eulerAngles = new Vector2(0, 180);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
        }

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

        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            sr.color = Color.white;
        }
        

    }


    private void FixedUpdate()
    {

        moveHorizontal();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        countDown = 1;
            sr.color = Color.red;
            
        
        
    }

    private void moveHorizontal()
    {

        //Get the value of the Horizontal input axis.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

       // transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }

    private void jump()
    {

        float verticalInput = Input.GetAxisRaw("Vertical");
        //Get the value of the Vertical input axis.
        rb.AddForce(Vector2.up  * 500);
  
        //transform.Translate(new Vector3(0, verticalInput, 0) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }
}