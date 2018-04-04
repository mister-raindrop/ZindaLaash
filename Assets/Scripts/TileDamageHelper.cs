using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDamageHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform tile in transform) {
            tile.gameObject.AddComponent<DamagingTiles>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
