using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossStatsController : MonoBehaviour {

    public int maxHP;
    public int currHP;

    // Use this for initialization
    void Start()
    {
        maxHP = 5;
        currHP = 5;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            StartCoroutine(HitnDestroy(collision));
        }
    }

    IEnumerator HitnDestroy(Collision2D col)
    {
        yield return new WaitForSeconds(0.5f);
        try
        {
            Destroy(col.gameObject);
        }
        catch(NullReferenceException e)
        {
            Debug.Log(e.Message);
        }
    }
    
}
