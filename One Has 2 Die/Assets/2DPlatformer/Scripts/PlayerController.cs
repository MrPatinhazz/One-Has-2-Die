using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;


    //Moveset
    private string _horizontal;
    public string HorizontalP1 = "Horizontal_P1";
    public string HorizontalP2 = "Horizontal_P2";

    private string _jump;
    public string JumpP1 = "Jump_P1";
    public string JumpP2 = "Jump_P2";

    private void Awake()
    {
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
    }

    // Use this for initialization
    void Start()
    {

    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis(_horizontal);

        if (Input.GetButtonDown(_jump))

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
    }
}
