using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZObjectPools;

public class SpawnZombies : MonoBehaviour {

    public GameObject zombiePrefab;
    EZObjectPool zombiePool;
    List<GameObject> spawnPoints;

    private void Awake() {
        zombiePool = EZObjectPool.CreateObjectPool(zombiePrefab, "ZombiePool", 20, true, true, true);
    }

    // Use this for initialization
    void Start () {
        spawnPoints = new List<GameObject>();
        foreach (Transform spawn in transform) {
            spawnPoints.Add(spawn.gameObject);
        }

        InvokeRepeating("SpawnZombie", 1f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnZombie () {

        Transform spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;
        GameObject zombie;
        if (zombiePool.TryGetNextObject(spawnPosition.position, spawnPosition.rotation, out zombie)) {
            zombie.GetComponent<CapsuleCollider>().enabled = true;
            zombie.GetComponent<Rigidbody>().isKinematic = false;
            zombie.GetComponent<ZombieHealth>().zombieHealth = 60f;
            Debug.Log("Spawned");
        }
    }
}
