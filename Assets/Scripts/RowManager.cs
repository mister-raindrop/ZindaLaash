using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RowManager : MonoBehaviour {

    private GameObject[] tiles;
    private Queue<GameObject> gq;
    public float timeBetweenRows = 3f;
    private float timer = 1.5f;
    public GameObject row1, row2, row3;

    // Use this for initialization
    void Start() {
        CreateInitialDetail();

        tiles = GameObject.FindGameObjectsWithTag("Floor");
        Debug.Log("Floored");
        Array.Sort(tiles, delegate(GameObject a, GameObject b) {
            return (float.Parse(a.name)).CompareTo((float.Parse(b.name)));
        });

        foreach (GameObject go in tiles) {
            Debug.Log(go.name);
            go.SetActive(false);
            foreach (Transform tile in go.transform) {
                tile.gameObject.tag = "Tile";
                /*if (tile.childCount > 0) {
                    tile.GetChild(0).gameObject.SetActive(false);
                }*/
            }
        }

        gq = new Queue<GameObject>(tiles);
    }


	// Update is called once per frame
	void Update () {
        if (gq.Count > 0) {
            timer += Time.deltaTime;
            if (timer > timeBetweenRows) {
                timer = 0f;
                StartCoroutine(SpawnTileRows(gq.Dequeue()));
            }
        }
	}


    IEnumerator SpawnTileRows (GameObject tileRow) {
        //yield return new WaitForSeconds(seconds);
        tileRow.SetActive(true);
        foreach (Transform tile in tileRow.transform) {
            Debug.Log("Detailing Tilerow " + tileRow.name);
            tile.gameObject.SetActive(true);
            tile.gameObject.GetComponent<TileStuff>().CreateDetail();
        }
        /*foreach (Transform tile in tileRow.transform) {
            if (tile.childCount > 0) {
                tile.GetChild(0).gameObject.SetActive(true);
            }
        }*/
        yield return null;
    }


    private void CreateInitialDetail () {
        Debug.Log("Create Initial Detail");
        foreach (Transform tile in row1.transform) {
            tile.gameObject.GetComponent<TileStuff>().CreateDetail();
        }

        foreach (Transform tile in row2.transform) {
            tile.gameObject.GetComponent<TileStuff>().CreateDetail();
        }

        foreach (Transform tile in row3.transform) {
            tile.gameObject.GetComponent<TileStuff>().CreateDetail();
        }
    }
}
