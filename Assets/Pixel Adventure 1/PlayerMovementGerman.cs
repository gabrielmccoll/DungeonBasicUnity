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

    private enum MovementState {idle,running,jumping,falling }
    


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
        MoveHorizontal();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

    }

    private void MoveHorizontal()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

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
        MovementState state;
     
        if (horizontal > 0f)
        {
            state = MovementState.running;
            sr.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.running;
            sr.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }


        anim.SetInteger("movementState", (int)state);
    }
}

