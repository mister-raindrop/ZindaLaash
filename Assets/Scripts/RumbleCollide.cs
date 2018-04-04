using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleCollide : MonoBehaviour {

    public Transform origTrans;
    private void Awake() {
        
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Respawn") && transform.parent.gameObject.activeSelf) {
            foreach (Transform cube in transform.parent) {
                cube.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                cube.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                cube.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                cube.transform.rotation = cube.gameObject.GetComponent<RumbleCollide>().origTrans.rotation;
                cube.transform.localRotation = cube.gameObject.GetComponent<RumbleCollide>().origTrans.localRotation;
                cube.transform.position = cube.gameObject.GetComponent<RumbleCollide>().origTrans.position;
                cube.transform.localPosition = cube.gameObject.GetComponent<RumbleCollide>().origTrans.localPosition;
            }
            //transform.rotation = origTrans.rotation;
            //transform.localRotation = origTrans.localRotation;
            //transform.position = origTrans.position;
            //transform.localPosition = origTrans.localPosition;
            transform.parent.gameObject.SetActive(false);
        }
    }


    private void OnDisable() {
        Debug.Log("Disabled");
        
    }

    private void OnEnable() {
        //origTrans = transform;
        Debug.Log("Enabled");
        origTrans = transform;
       // GetComponent<Rigidbody>().isKinematic = false;
    }
}
