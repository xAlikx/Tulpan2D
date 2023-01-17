using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed;
    public float jumpStrength;

    private Vector2 movement;
    private bool turnRight = true;
    
    void Start()
    {
    }
    
    void Update()
    {
        turnRight = movement.x == 0 ? turnRight : movement.x > 0;
        
        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("TurnRight", turnRight);
        Debug.Log($"velocity after: {movement.sqrMagnitude}");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector2.up * jumpStrength);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
