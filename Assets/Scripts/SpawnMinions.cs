using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZObjectPools;

public class SpawnMinions : MonoBehaviour {

    public GameObject minionPrefab;
    EZObjectPool minionPool;
    List<GameObject> spawnPoints;

    private void Awake() {
        minionPool = EZObjectPool.CreateObjectPool(minionPrefab, "MinionPool", 20, true, true, true);
    }

    // Use this for initialization
    void Start() {
        spawnPoints = new List<GameObject>();
        foreach (Transform spawn in transform) {
            spawnPoints.Add(spawn.gameObject);
        }

        InvokeRepeating("SpawnMinion", 1f, 3f);
    }

    // Update is called once per frame
    void Update() {

    }

    void SpawnMinion() {

        Transform spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;
        GameObject minion;
        if (minionPool.TryGetNextObject(spawnPosition.position, spawnPosition.rotation, out minion)) {
            minion.GetComponent<CapsuleCollider>().enabled = true;
            minion.GetComponent<Rigidbody>().isKinematic = false;
            minion.GetComponent<MinionHealth>().minionHealth = 90f;
            Debug.Log("Spawned");
        }
    }
}
