using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuHelpBehaviour : MonoBehaviour {
    public GameObject HelpText;
    public GameObject BackButton;
    public GameObject QuitButton;
    public GameObject PlayButton;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        
    }


    public void ClickHelp () {
        PlayButton.SetActive(false);
        QuitButton.SetActive(false);
        gameObject.SetActive(false);
        HelpText.SetActive(true);
        BackButton.SetActive(true);
    }
}
