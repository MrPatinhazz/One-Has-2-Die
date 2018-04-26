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

    private Animator anim;                     // Reference to the Animator component.
    public string _shootB;                     // Shooting button

    public float pSpeed = 5;               // The speed the rocket will fire at.

    void Awake()
    {
        // Setting up the references.
        //anim = transform.root.gameObject.GetComponent<Animator>();
        projectile.GetComponent<SpriteRenderer>().sprite = projectileSprite;
        projRb2d = projectile.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButton(_shootB))
        {
            Shoot();
        }
    }

    void Start()
    {
        
    }

    private void Shoot()
    {
        Vector3 inputDir = Vector3.zero;
        inputDir.x = Input.GetAxis("R_XAxis_1");
        inputDir.y = Input.GetAxis("R_YAxis_1");        
        Vector3 spawnPos = transform.parent.position + new Vector3(0, 0.46f, 0) + Vector3.ClampMagnitude(inputDir, 0.5f);
        // ... instantiate the projectile facing right and set it's velocity to the right. 
        Rigidbody2D bulletInstance = Instantiate(projRb2d, spawnPos, Quaternion.Euler(projRot),transform.parent) as Rigidbody2D;
        bulletInstance.velocity = new Vector2(pSpeed, 5);
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere((this.transform.parent.position) + new Vector3(0,0.46f,0), 0.5f);
    //    Vector3 inputDir = Vector3.zero;
    //    inputDir.x = Input.GetAxis("R_XAxis_1");
    //    inputDir.y = Input.GetAxis("R_YAxis_1");
    //    Gizmos.DrawLine((this.transform.parent.position) + new Vector3(0, 0.46f, 0), transform.parent.position + new Vector3(0, 0.46f, 0) + Vector3.ClampMagnitude(inputDir, 1f));
    //    Gizmos.DrawSphere(transform.parent.position + new Vector3(0, 0.46f, 0) + Vector3.ClampMagnitude(inputDir, 1f), 0.1f);
    //}
}
