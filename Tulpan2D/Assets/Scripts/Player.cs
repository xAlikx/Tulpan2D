using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed;
    public float jumpStrength;

    private Vector2 prevMovement;
    private Vector2 movement;
    private bool turnRight = true;
    private bool isGrounded;
    
    void Start()
    {
    }
    
    void Update()
    {
        prevMovement = new Vector2(movement.x, movement.y);
        movement.x = Input.GetAxisRaw("Horizontal");
        turnRight = movement.x == 0 ? turnRight : movement.x > 0;
        

        Jump();
    }

    void FixedUpdate()
    {
        CheckGrounded();
        Move();
    }


    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpStrength, ForceMode2D.Impulse);
        }

        if (!isGrounded)
        {
            if (movement.x > 0)
                animator.SetInteger("State", (int)AnimationState.JumpRight);
            else if (movement.x < 0)
                animator.SetInteger("State", (int)AnimationState.JumpLeft);
        }
    }

    private void Move()
    {
        Vector3 dir = transform.right * movement;
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + dir, moveSpeed * Time.deltaTime);

        if (isGrounded)
        {
            if (movement.x > 0)
                animator.SetInteger("State", (int)AnimationState.WalkRight);
            else if (movement.x < 0)
                animator.SetInteger("State", (int)AnimationState.WalkLeft);
            else if (movement.x == 0 && prevMovement.x > 0)
                animator.SetInteger("State", (int)AnimationState.IdleRight);
            else if (movement.x == 0 && prevMovement.x < 0)
                animator.SetInteger("State", (int)AnimationState.IdleLeft);
            else
                animator.SetInteger("State", (int)AnimationState.IdleRight);
        }
    }

    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircleAll(transform.position, 0.7f).Length > 1;
    }
    
    private enum AnimationState
    {
        IdleRight = 0,
        IdleLeft = 1,
        WalkRight = 2,
        WalkLeft = 3,
        JumpRight = 4,
        JumpLeft = 5
    }
}
