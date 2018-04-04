using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour {

    public int maxHP;
    public int currHP;

	// Use this for initialization
	void Start () {
        maxHP = 5;
        currHP = 5;
	}

    public void IncrMaxHP()
    {
        maxHP++;
    }
	
}
