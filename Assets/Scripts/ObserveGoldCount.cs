using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObserveGoldCount : MonoBehaviour {

    public Text goldCountText;
    public GameObject player;

    private int goldCount = 0;
    
	// Use this for initialization
	void Start () {
        goldCountText.text = "Gold: " + goldCount;

        //
        WhatIsThePlayerStandingOn.Announce_GotThatCash += UpdateGoldCount;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateGoldCount()
    {
        goldCount++;
        goldCountText.text = "Gold: " + goldCount;
    }
}
