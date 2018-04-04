using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {
    public float zombieHealth = 90f;
    private PlayerHealth pHealth;
    private Animator anim;
    private AudioSource zombieDedSound;
	// Use this for initialization
	void Start () {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        zombieDedSound = GetComponents<AudioSource>()[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void zombieTakeDamage (float damage) {
        if (zombieHealth > 0) {
            zombieHealth -= damage;
            if (zombieHealth <= 0) {
                pHealth.playerGainHealth(5f);
                anim.SetBool("Death", true);
                zombieDedSound.Play();
                StartCoroutine(DeathAnimDelay());
                //gameObject.SetActive(false);
            }
        }
    }

    IEnumerator DeathAnimDelay () {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
