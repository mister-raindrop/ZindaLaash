using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    public float speed = 50;
    public float zombieDamage = 10f;
    private Rigidbody rBody;
    //private CapsuleCollider cap;
    private ZombieHealth zHealth;
 

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody>();
        //cap = GetComponent<CapsuleCollider>();
        zHealth = GetComponent<ZombieHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void FixedUpdate() {
        if (zHealth.zombieHealth > 0) {
            rBody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Respawn")) {
            gameObject.SetActive(false);
        }
    }

}
