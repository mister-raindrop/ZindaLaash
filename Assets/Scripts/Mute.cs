using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {
    public Sprite SoundOn;
    public Sprite SoundOff;
    private bool audioToggle = true;
    private Image audioImage;
	// Use this for initialization
	void Start () {
        audioImage = GetComponent<Image>();
        if (PlayerPrefs.GetInt("Sound", 1) == 1) {
            audioToggle = true;
            audioImage.sprite = SoundOff;
            AudioListener.volume = 1f;
        } else {
            audioToggle = false;
            audioImage.sprite = SoundOn;
            AudioListener.volume = 0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SoundClick () {
        audioToggle = !audioToggle;

        if (audioToggle) {
            AudioListener.volume = 1f;
            PlayerPrefs.SetInt("Sound", 1);
            audioImage.sprite = SoundOff;
        } else {
            AudioListener.volume = 0f;
            PlayerPrefs.SetInt("Sound", 0);
            audioImage.sprite = SoundOn;
        }
    }
}
