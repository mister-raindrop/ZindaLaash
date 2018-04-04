using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayBehaviour : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Sound", 1);
        AudioListener.volume = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SwitchToPlayScene () {
        SceneManager.LoadScene("protoscene", LoadSceneMode.Single);
    }
}
