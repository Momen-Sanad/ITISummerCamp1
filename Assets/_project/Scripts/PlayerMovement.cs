using UnityEngine;
using UnityEngine.UI;
//make lava to hit and die,
//make a restart button that resets the scene,
//fix the levers,
//make some sort of unique effect on certain grounds,
//make singelton score system,
//make it display on canvas top left,
//make a return to main menu button top right, 


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float horizontalSpeed = 5f;
    [SerializeField] float jumpForce = 3f;

    [Header("Ground Check")]
    [SerializeField] float groundCheckDistance = 0.1f;   // small ray distance for ground detection
    [SerializeField] LayerMask groundLayer;              

    Rigidbody2D rb;
    Animator anim;

    bool isGrounded = true;
    bool isJumping = false;
    bool isRunning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();

        var wasGrounded = isGrounded;
        // Cast a ray downward to check if on the ground
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
        

        // If just landed
        if (!wasGrounded && isGrounded)
            Land();
        

        // Running animation handler
        if (isGrounded && !isJumping && !isRunning)
        {
            anim.SetBool("isRunning", true);
            isRunning = true;
        }
    }

    void HandleMovement() => MoveChar();
        

    void MoveChar()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontalDirection * Time.deltaTime * horizontalSpeed);

        anim.SetBool("isRunning", horizontalDirection != 0);

        // Flip player sprite when moving left/right
        if (horizontalDirection > 0)
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);   // Face right
        else if (horizontalDirection < 0)
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);  // Face left
    }

    void Jump()
    {
        isJumping = true;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // direct velocity
        anim.SetTrigger("isJump");
        anim.SetBool("isRunning", false);
        isRunning = false;
    }

    void Land()
    {
        isJumping = false;
        anim.SetBool("isRunning", true);
        isRunning = true;
    }

}
