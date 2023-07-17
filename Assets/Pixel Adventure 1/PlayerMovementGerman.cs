using UnityEngine;

public class PlayerMovementGerman : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    [SerializeField] private float jumpForce = 14.0f;
    [SerializeField] private float moveSpeed = 7.0f;
    private bool isRunning;
    float horizontal = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

    }

    private void FixedUpdate()
    {
        UpdateAnimationState();


          
        
    }

    private void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    private void UpdateAnimationState()
    {
        if (horizontal > 0f)
        {
            anim.SetBool("isRunning", true);
            sr.flipX = false;
        }
        else if (horizontal < 0f)
        {
            anim.SetBool("isRunning", true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
           
        }
    }
}

