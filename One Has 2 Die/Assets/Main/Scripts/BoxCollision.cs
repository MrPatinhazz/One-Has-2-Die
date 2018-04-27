using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BoxCollision : MonoBehaviour {

    private GameObject player1;

	// Use this for initialization
	void Start () {
        player1 = GameObject.Find("Player_1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (this.name == "Box1")
        {
            if (col.gameObject.name == "Player_1")
            {
                Debug.Log("teste box 1");
                //player1.GetComponent<PlayerStatsController>().IncrMaxHP();
                


                //Destroy(this.gameObject);
                //StartCoroutine(HitnDestroy(col));
            }
        }

        if (this.name == "Box2")
        {
            if (col.gameObject.name == "Player_1")
            {
                Debug.Log("teste box 2");
                //player1.GetComponent<PlayerStatsController>().IncrSpeed();

                //Destroy(this.gameObject);
                //StartCoroutine(HitnDestroy(col));
            }
        }
    }

    /*IEnumerator HitnDestroy(Collision2D col)
    {
        yield return new WaitForSeconds(0.5f);
        try
        {
            Destroy(col.gameObject);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }
    }*/


}
