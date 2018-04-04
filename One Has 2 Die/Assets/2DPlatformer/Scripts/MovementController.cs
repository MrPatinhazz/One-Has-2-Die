using UnityEngine;

public class MovementController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spRender;
    private Animator animator;

    public bool facingRight;

    //Moveset
    private string _horizontal;
    public string HorizontalP1 = "Horizontal_P1";
    public string HorizontalP2 = "Horizontal_P2";

    private string _jump;
    public string JumpP1 = "Jump_P1";
    public string JumpP2 = "Jump_P2";

    private void Awake()
    {
        facingRight = true;

        if (gameObject.name == "Player_1")
        {
            _horizontal = HorizontalP1;
            _jump = JumpP1;
        }
        else if (gameObject.name == "Player_2")
        {
            _horizontal = HorizontalP2;
            _jump = JumpP2;
        }

        spRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis(_horizontal);

        if (Input.GetButtonDown(_jump) && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp(_jump))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;

            }
        }

        targetVelocity = move * maxSpeed;

        //Flips character sprite depending on x movement.
        bool flipSprite = (spRender.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSprite)
        {
            facingRight = !facingRight;
            spRender.flipX = !spRender.flipX;
        }

        //Sets right sprite for grounded and walking position
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
    }
}
