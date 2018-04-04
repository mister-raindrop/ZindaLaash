using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject PausePanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    public void PauseClick () {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
}
