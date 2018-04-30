using UnityEngine;

public class MovementController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    public GameObject skeleton;
    private Animator animator;
    private Rigidbody2D m_rb2d;

    public bool facingRight;

    //Moveset
    public string horinzontalAxis;
    public string jumpButton;

    private void Awake()
    {
        facingRight = true;
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis(horinzontalAxis);

        if (Input.GetButtonDown(jumpButton) && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            animator.SetFloat("speedY", velocity.y);
        }
        else if (Input.GetButtonUp(jumpButton))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
        }

        targetVelocity = move * maxSpeed;

        bool flipSprite = (skeleton.transform.localScale.x < 0 ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSprite)
        {
            facingRight = !facingRight;
            Vector3 newScale = skeleton.transform.localScale;
            newScale.x *= -1;
            skeleton.transform.localScale = newScale;
        }

        
        animator.SetBool("grounded", grounded);
        animator.SetFloat("speedX", Mathf.Abs(velocity.x) / maxSpeed);
    }
}
