using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleFall : MonoBehaviour {
    private Rigidbody rBody;
    // Use this for initialization
    void Start() {
        rBody = GetComponent<Rigidbody>();
        rBody.isKinematic = false;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Respawn")) {
            rBody.isKinematic = true;
            rBody.velocity = Vector3.zero;
            rBody.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

}
    
