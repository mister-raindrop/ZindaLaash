using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {
    public GameObject PausePanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResumeClick () {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
