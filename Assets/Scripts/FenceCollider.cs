using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCollider : MonoBehaviour {

    private PlayerHealth pHealth;

	// Use this for initialization
	void Start () {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Zombie")) {
            pHealth.playerTakeDamage(other.gameObject.GetComponent<Zombie>().zombieDamage);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Minion")) {
            pHealth.playerTakeDamage(other.gameObject.GetComponent<Minion>().minionDamage);
            other.gameObject.SetActive(false);
        }
    }
}
