using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour
{
    public Rigidbody2D projectile;          // Prefab of the rocket.
    public GameObject projectSpawn;
    public float speed = 20f;               // The speed the rocket will fire at.

    private string _shoot;
    public string shootButtonP1 = "Shoot_P1";
    public string shootButtonP2 = "Shoot_P2";

    private MovementController playerCtrl;       // Reference to the MovementControl script.
    private Animator anim;                     // Reference to the Animator component.

    void Awake()
    {
        // Setting up the references.
        //anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = GetComponent<MovementController>();

        if (gameObject.name == "Player_1")
        {
            _shoot = shootButtonP1;
        }
        else if (gameObject.name == "Player_2")
        {
            _shoot = shootButtonP2;
        }
    }


    void Update()
    {
        // If the fire button is pressed...
        if (Input.GetButtonDown(_shoot))
        {
            // ... set the animator Shoot trigger parameter and play the audioclip.
            //anim.SetTrigger("Shoot");
            //audio.Play();

            // If the player is facing right...
            if (playerCtrl.facingRight)
            {
                // ... instantiate the projectile facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(projectile, projectSpawn.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                // Otherwise instantiate the projectile facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(projectile, projectSpawn.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }
    }
}
