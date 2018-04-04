using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZObjectPools;

public class TileStuff : MonoBehaviour {
    public float minWaitTime = 3f;
    public float maxWaitTime = 6f;
    private GameObject detailSpawner;
    private MeshRenderer meshRenderer;
    private BoxCollider boxColl;
    public Color origColor;
    private Color undamageableCol;
    

    // Use this for initialization
    void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        boxColl = GetComponent<BoxCollider>();
        origColor = meshRenderer.material.color;
        ColorUtility.TryParseHtmlString("#30600FFF", out undamageableCol);
        detailSpawner = GameObject.FindGameObjectWithTag("Detail");
        //CreateDetail();
	}
	
	// Update is called once per frame
	void Update () {
       /*if (meshRenderer.material.color != origColor) {
            StartCoroutine(UnbreakableHelper());
        }*/
        /*if (!gameObject.activeSelf) {
            if (gameObject.transform.childCount > 0) {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }*/
	}

    /*private void OnMouseDown() {
        if (timer <= 5f) {
            timer = 0f;
            Debug.Log(gameObject.name);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponentInParent<NavMeshSurface>().BuildNavMesh();
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Zombie")) {
                go.GetComponent<NavMeshAgent>().SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            StartCoroutine(Reappear());
        } else {
            timer = 0f;
        }
    }*/

    public void DestroyTile() {
        if (meshRenderer.material.color == origColor) {
            meshRenderer.enabled = false;
            boxColl.enabled = false;
            GameObject tempRumble;
            detailSpawner.GetComponent<DetailHelper>().RumblePool.TryGetNextObject(transform.position, transform.rotation, out tempRumble);
            tempRumble.GetComponent<Rigidbody>().isKinematic = false;
            if (transform.childCount > 0) {
                GameObject child = transform.GetChild(0).gameObject;
                child.transform.parent = null;
                child.SetActive(false);
            }
        }
    }


    public IEnumerator Reappear() {
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime + 1f));
        
        if (Random.Range(0.0f, 1.0f) <= 0.2) {
            //meshRenderer.material.SetColor("_Color", Color.blue);
            meshRenderer.material.SetColor("_Color", undamageableCol);
            meshRenderer.enabled = true;
            boxColl.enabled = true;
            CreateDetail();
            StartCoroutine(UnbreakableHelper());
        } else {
            meshRenderer.material.SetColor("_Color", origColor);
            meshRenderer.enabled = true;
            boxColl.enabled = true;
            CreateDetail();
        }
    }

   
    private IEnumerator UnbreakableHelper () {
        yield return new WaitForSeconds(6f);
        //meshRenderer.material.SetColor("_Color", origColor);
        //DestroyTile();
        meshRenderer.enabled = false;
        boxColl.enabled = false;
        GameObject tempRumble;
        detailSpawner.GetComponent<DetailHelper>().RumblePool.TryGetNextObject(transform.position, transform.rotation, out tempRumble);
        tempRumble.GetComponent<Rigidbody>().isKinematic = false;

        if (transform.childCount > 0) {
            GameObject child = transform.GetChild(0).gameObject;
            child.transform.parent = null;
            child.SetActive(false);
        }
        StartCoroutine(Reappear());

    }


    public void CreateDetail () {
        if (Random.Range(0.0f, 1.0f) <= 0.4f) {
            if (Random.Range(0.0f, 1.0f) <= 0.5) {
                GameObject cactus;
                //detailSpawner.GetComponent<DetailHelper>().CactusPool.TryGetNextObject(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity, out cactus);
                GameObject.FindGameObjectWithTag("Detail").GetComponent<DetailHelper>().CactusPool.TryGetNextObject(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity, out cactus);
                cactus.transform.SetParent(transform);
            } else {
                GameObject aloe;
                //detailSpawner.GetComponent<DetailHelper>().AloePool.TryGetNextObject(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity, out aloe);
                GameObject.FindGameObjectWithTag("Detail").GetComponent<DetailHelper>().AloePool.TryGetNextObject(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity, out aloe);

                aloe.transform.SetParent(transform);
            }
        }
    }  
}
