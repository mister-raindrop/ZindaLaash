using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

    public float speed = 50;
    public float minionDamage = 10f;
    private Rigidbody rBody;
    private CapsuleCollider cap;
    private MinionHealth mHealth;

    // Use this for initialization
    void Start() {
        rBody = GetComponent<Rigidbody>();
        cap = GetComponent<CapsuleCollider>();
        mHealth = GetComponent<MinionHealth>();
    }

    // Update is called once per frame
    void Update() {

    }


    private void FixedUpdate() {
        if (mHealth.minionHealth > 0) {
            rBody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Respawn")) {
            gameObject.SetActive(false);
        }
    }
}
