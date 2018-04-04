using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHelper : MonoBehaviour {
    public float score = 0f;
    public GameObject textObjScore;
    public GameObject textObjHighscore;
    private TextMeshProUGUI textFieldScore;
    private TextMeshProUGUI textFieldHighscore;
    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        textFieldScore = textObjScore.GetComponent<TextMeshProUGUI>();
        textFieldScore.SetText("Score: " + score.ToString("F2"));

        textFieldHighscore = textObjHighscore.GetComponent<TextMeshProUGUI>();
        textFieldHighscore.SetText("Highscore: " + (PlayerPrefs.GetFloat("Highscore", 0.0f)).ToString("F2"));
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth.playerHealth > 0) {
            score += Time.deltaTime;
        }
        textFieldScore.SetText("Score: " + score.ToString("F2"));
        if (score > PlayerPrefs.GetFloat("Highscore")) {
            PlayerPrefs.SetFloat("Highscore", score);
            textFieldHighscore.SetText("Highscore: " + (PlayerPrefs.GetFloat("Highscore", 0.0f)).ToString("F2"));
        }
	}
}
