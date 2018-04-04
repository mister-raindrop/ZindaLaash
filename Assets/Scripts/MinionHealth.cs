using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealth : MonoBehaviour {

    public float minionHealth = 90f;
    private PlayerHealth pHealth;
    private Animator anim;
    private AudioSource minionDedSound;
    // Use this for initialization
    void Start() {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        minionDedSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void minionTakeDamage(float damage) {
        if (minionHealth > 0) {
            minionHealth -= damage;
            if (minionHealth <= 0) {
                pHealth.playerGainHealth(3f);
                anim.SetBool("MinionDeath", true);
                minionDedSound.Play();
                StartCoroutine(mDeathAnimDelay());
            }
        }
    }


    IEnumerator mDeathAnimDelay() {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
