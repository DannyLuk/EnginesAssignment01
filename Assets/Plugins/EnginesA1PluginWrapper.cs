using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class EnginesA1PluginWrapper : MonoBehaviour {

    const string DLL_NAME = "EnginesA1DLL";

    [DllImport(DLL_NAME)]
    private static extern int GetRandomNumber(int floor, int ceiling);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(GetRandomNumber(0, 10));
        }
	}
}
