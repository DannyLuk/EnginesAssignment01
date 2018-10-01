using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour {

    public GameObject controlRemappingPanel;

	// Use this for initialization
	void Start () {
        controlRemappingPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleMenuVisibility()
    {
        if (controlRemappingPanel.activeSelf == false)
        {
            controlRemappingPanel.SetActive(true);
        }
        else if (controlRemappingPanel.activeSelf == true)
        {
            controlRemappingPanel.SetActive(false);
        }
    }
}
