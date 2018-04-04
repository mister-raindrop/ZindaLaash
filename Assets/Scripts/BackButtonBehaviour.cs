using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonBehaviour : MonoBehaviour {
    public GameObject HelpText;
    public GameObject HelpButton;
    public GameObject QuitButton;
    public GameObject PlayButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickBack() {
        PlayButton.SetActive(true);
        QuitButton.SetActive(true);
        HelpButton.SetActive(true);
        HelpText.SetActive(false);
        gameObject.SetActive(false);
    }
}
