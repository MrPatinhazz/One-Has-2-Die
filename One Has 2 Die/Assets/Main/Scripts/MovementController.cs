﻿using UnityEngine;

public class MovementController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spRender;
    private Animator animator;
    private Rigidbody2D m_rb2d;

    public bool facingRight;

    //Moveset
    public string horinzontalAxis;
    public string jumpButton;

    private void Awake()
    {
        facingRight = true;

        spRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis(horinzontalAxis);

        if (Input.GetButtonDown(jumpButton) && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            //animator.SetFloat("jumpTakeOffSpeed", velocity,y);
        }
        else if (Input.GetButtonUp(jumpButton))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
        }

        targetVelocity = move * maxSpeed;

        //bool flipSprite = (spRender.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        //if (flipSprite)
        //{
        //    facingRight = !facingRight;
        //    spRender.flipX = !spRender.flipX;
        //}

        
        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
    }
}