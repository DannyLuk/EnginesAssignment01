using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhatIsThePlayerStandingOn : MonoBehaviour {

    //
    public bool flyweight = true;

    //
    public delegate void GotThatCash();
    public static event GotThatCash Announce_GotThatCash;

    public Text terrainDataText;
    public GameObject terrainDataGameObject;
    private TerrainDataSource terrainData;

    private string terrainDesciption;
    private string terrainDefenceBonus;
    private string terrainMovementBonus;

    // Use this for initialization
    void Start () {
        terrainData = terrainDataGameObject.GetComponent<TerrainDataSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //
        terrainDataText.text = "Defence Bonus: " + terrainDefenceBonus + "\nMove Bonus: " + terrainMovementBonus + "\nTile Description: " + terrainDesciption;
    }

    //
    private void OnCollisionStay(Collision collision)
    {
        //
        if (flyweight == true)
        {
            if (collision.gameObject.tag == "Dirt")
            {
                terrainDesciption = terrainData.tileDescriptionDirt;
                terrainDefenceBonus = terrainData.tileDefenceBonusDirt.ToString();
                terrainMovementBonus = terrainData.tileMovementBonusDirt.ToString();
            }
            if (collision.gameObject.tag == "Grass")
            {
                terrainDesciption = terrainData.tileDescriptionGrass;
                terrainDefenceBonus = terrainData.tileDefenceBonusGrass.ToString();
                terrainMovementBonus = terrainData.tileMovementBonusGrass.ToString();
            }
            if (collision.gameObject.tag == "Water")
            {
                terrainDesciption = terrainData.tileDescriptionWater;
                terrainDefenceBonus = terrainData.tileDefenceBonusWater.ToString();
                terrainMovementBonus = terrainData.tileMovementBonusWater.ToString();
            }
            if (collision.gameObject.tag == "Treasure")
            {
                terrainDesciption = terrainData.tileDescriptionTreasure;
                terrainDefenceBonus = terrainData.tileDefenceBonusTreasure.ToString();
                terrainMovementBonus = terrainData.tileMovementBonusTreasure.ToString();
                // Broadcast the event
                if (Announce_GotThatCash != null && (collision.gameObject.transform.GetChild(0).gameObject.activeSelf == true))
                {
                    Announce_GotThatCash();
                }
                // Remove that gold pile
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (flyweight == false)
        {
            terrainDesciption = collision.gameObject.GetComponent<NoFlyTerrainData>().tileDescription;
            terrainDefenceBonus = collision.gameObject.GetComponent<NoFlyTerrainData>().tileDefenceBonus.ToString();
            terrainMovementBonus = collision.gameObject.GetComponent<NoFlyTerrainData>().tileMovementBonus.ToString();
            if (collision.gameObject.tag == "Treasure")
            {
                // Broadcast the event
                if (Announce_GotThatCash != null && (collision.gameObject.transform.GetChild(0).gameObject.activeSelf == true))
                {
                    Announce_GotThatCash();
                }
                // Remove that gold pile
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
