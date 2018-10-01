using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MapGenerator : MonoBehaviour {

    // Setting up the DLL
    const string DLL_NAME = "EnginesA1DLL";
    [DllImport(DLL_NAME)]
    private static extern int GetRandomNumber(int floor, int ceiling);

    public List<GameObject> tilePool = new List<GameObject>();

    // Use this for initialization
    void Start () {
        // 
        int tileIndex = 0;
        int spawnTreasure = 0;

        //
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                // Determine tile type to generate
                tileIndex = Random.Range(0, tilePool.Count-1);

                // Will we spawn a treasure tile?? Let's use the DLL to roll for the spawn chance!!
                spawnTreasure = GetRandomNumber(0, 10);

                // Treasure Get!!
                if (spawnTreasure == 0)
                {
                    GameObject tile = (GameObject)Instantiate(tilePool[3], new Vector3(-50 + i, 0, -50 + j), Quaternion.identity);
                    tile.transform.SetParent(this.transform);
                }
                else
                {
                    // Generate tile
                    GameObject tile = (GameObject)Instantiate(tilePool[tileIndex], new Vector3(-50 + i, 0, -50 + j), Quaternion.identity);
                    tile.transform.SetParent(this.transform);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
