using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingTiles : MonoBehaviour {
    private PlayerHealth pHealth;
    private float tileDamage = 1f;
    private float timeBetweenTicks = 1f;
    private float timer;
    private bool canDamage;
    private TileStuff tileStuff;
    private MeshRenderer meshRenderer;
    private BoxCollider boxColl;
	// Use this for initialization
	void Start () {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        meshRenderer = GetComponent<MeshRenderer>();
        tileStuff = GetComponent<TileStuff>();
        boxColl = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (canDamage) {
            pHealth.playerTakeDamage(tileDamage);
            canDamage = false;
        }
	}


    private void OnTriggerEnter(Collider other) {
        timer = 0f;
    }

    private void OnTriggerStay(Collider other) {
        if (other.name == "PlayerTile" && meshRenderer.material.color == tileStuff.origColor && boxColl.enabled) {
            timer += Time.deltaTime;
            if (timer >= timeBetweenTicks && !canDamage) {
                canDamage = true;
                timer = 0;
            }
            
        }
    }
}
