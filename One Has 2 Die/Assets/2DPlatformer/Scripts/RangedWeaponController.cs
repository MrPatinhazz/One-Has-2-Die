using UnityEngine;
using System.Collections;
using System;

public class RangedWeaponController : MonoBehaviour
{
    public GameObject projectile;          // Ref to projectile prefab
    public Sprite projectileSprite;        // Projectile Prefab
    private Rigidbody2D projRb2d;          // Proj rigidbody

    private Vector3 projZRot = Vector3.zero;                  // Projectile rotation zero
    private Vector3 projRot = new Vector3(0,0,180);           // Projectile rotation 180º

    private bool _fRight;                      // Player facing right?
    private Animator anim;                     // Reference to the Animator component.
    public string _shootB;                     // Shooting button

    public float pSpeed = 5;               // The speed the rocket will fire at.
    public float shotSpacer = 0.3f;        // Time between shots
    private bool _canShoot;

    void Awake()
    {
        // Setting up the references.
        //anim = transform.root.gameObject.GetComponent<Animator>();
        _fRight = GetComponentInParent<MovementController>().facingRight;
        projectile.GetComponent<SpriteRenderer>().sprite = projectileSprite;
        projRb2d = projectile.GetComponent<Rigidbody2D>();

        _canShoot = true;
    }
    
    void Start()
    {
        InvokeRepeating("Shoot", 2, shotSpacer);
    }

    private void Shoot()
    {
        _fRight = GetComponentInParent<MovementController>().facingRight;

        // ... set the animator Shoot trigger parameter and play the audioclip.
        //anim.SetTrigger("Shoot");
        //audio.Play();

        if (_fRight)
        {
            // ... instantiate the projectile facing right and set it's velocity to the right. 
            Rigidbody2D bulletInstance = Instantiate(projRb2d, transform.position, Quaternion.Euler(projRot)) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(pSpeed, 5);
        }
        else
        {
            // Otherwise instantiate the projectile facing left and set it's velocity to the left.
            Rigidbody2D bulletInstance = Instantiate(projRb2d, transform.position, Quaternion.Euler(projZRot)) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(-pSpeed, 5);
        }

    }
}
