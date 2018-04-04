using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealth : MonoBehaviour {
    public float playerHealth = 100f;
    public Slider hpSlider;
    public GameObject ragdoll;
    public GameObject endgameUI;
    public GameObject gun;
    public GameObject charMesh;
    public GameObject highscoreText;
    public GameObject scoreText;
    public GameObject scoreObj;
    public GameObject inGameScore;
    public GameObject inGameHighscore;
    private AudioSource playerDedSound;

	// Use this for initialization
	void Start () {
        playerDedSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playerTakeDamage (float damage) {
        if (playerHealth > 0) {
            playerHealth -= damage;
            hpSlider.value = playerHealth;
            Debug.Log("Player Health: " + playerHealth);
            if (playerHealth <= 0) {
                Instantiate(ragdoll, gameObject.transform.position, gameObject.transform.rotation);
                //gameObject.SetActive(false);
                charMesh.GetComponent<SkinnedMeshRenderer>().enabled = false;
                gun.GetComponent<MeshRenderer>().enabled = false;
                playerDedSound.Play();
                StartCoroutine(EndScreen());
            }
        }
    }


    public void playerGainHealth (float health) {
        //playerHealth += health;
        //hpSlider.value = playerHealth;
        if ((playerHealth + health) >= 100f) {
            playerHealth = 100f;
            hpSlider.value = hpSlider.maxValue;
        } else {
            playerHealth += health;
            hpSlider.value = playerHealth;
        }
    }


    private IEnumerator EndScreen () {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;
        endgameUI.SetActive(true);
        inGameScore.SetActive(false);
        inGameHighscore.SetActive(false);
        highscoreText.GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetFloat("Highscore")).ToString("F2");
        scoreText.GetComponent<TextMeshProUGUI>().text = (scoreObj.GetComponent<ScoreHelper>().score).ToString("F2");
    }
}
