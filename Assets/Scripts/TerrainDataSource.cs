using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDataSource : MonoBehaviour {

    // Dirt Tile Data
    public string tileDescriptionDirt = "DIRT Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer hendrerit et nisi in fringilla. Nam vitae posuere velit. Curabitur vitae felis ante. Phasellus mattis orci dolor, nec mattis elit placerat eu. Maecenas purus urna, laoreet quis mi nec, consectetur accumsan nisi. In eu odio ligula. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam in lacus quis risus ultrices laoreet. Suspendisse aliquam libero ante, nec viverra enim euismod sit amet. Pellentesque interdum congue turpis, in suscipit augue rutrum non. Aenean eu lorem augue. Sed sed auctor lacus. Vivamus blandit erat sed velit tincidunt, ac consectetur nisl vulputate. Aliquam erat volutpat.";
    public int tileDefenceBonusDirt = 0;
    public int tileMovementBonusDirt = 1;

    // Grass Tile Data
    public string tileDescriptionGrass = "GRASS Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer hendrerit et nisi in fringilla. Nam vitae posuere velit. Curabitur vitae felis ante. Phasellus mattis orci dolor, nec mattis elit placerat eu. Maecenas purus urna, laoreet quis mi nec, consectetur accumsan nisi. In eu odio ligula. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam in lacus quis risus ultrices laoreet. Suspendisse aliquam libero ante, nec viverra enim euismod sit amet. Pellentesque interdum congue turpis, in suscipit augue rutrum non. Aenean eu lorem augue. Sed sed auctor lacus. Vivamus blandit erat sed velit tincidunt, ac consectetur nisl vulputate. Aliquam erat volutpat.";
    public int tileDefenceBonusGrass = 1;
    public int tileMovementBonusGrass = 0;

    // Water Tile Data
    public string tileDescriptionWater = "WATER Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer hendrerit et nisi in fringilla. Nam vitae posuere velit. Curabitur vitae felis ante. Phasellus mattis orci dolor, nec mattis elit placerat eu. Maecenas purus urna, laoreet quis mi nec, consectetur accumsan nisi. In eu odio ligula. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam in lacus quis risus ultrices laoreet. Suspendisse aliquam libero ante, nec viverra enim euismod sit amet. Pellentesque interdum congue turpis, in suscipit augue rutrum non. Aenean eu lorem augue. Sed sed auctor lacus. Vivamus blandit erat sed velit tincidunt, ac consectetur nisl vulputate. Aliquam erat volutpat.";
    public int tileDefenceBonusWater = -1;
    public int tileMovementBonusWater = -1;

    // Treasure Tile Data
    public string tileDescriptionTreasure = "YOHOHO!! THAR BE GOLD HERE!!";
    public int tileDefenceBonusTreasure = 0;
    public int tileMovementBonusTreasure = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
