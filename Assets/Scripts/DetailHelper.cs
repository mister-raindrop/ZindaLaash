using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZObjectPools;

public class DetailHelper : MonoBehaviour {
    public EZObjectPool CactusPool;
    public EZObjectPool AloePool;
    public EZObjectPool RumblePool;
    private GameObject cactusPrefab;
    private GameObject aloePrefab;
    public GameObject rumblePrefab;
    //private GameObject cactus;
    //private GameObject aloe;

    private void Awake() {
        cactusPrefab = Resources.Load("Cactus3") as GameObject;
        aloePrefab = Resources.Load("Aloe") as GameObject;
        CactusPool = EZObjectPool.CreateObjectPool(cactusPrefab, "CactusPool", 10, true, true, true);
        AloePool = EZObjectPool.CreateObjectPool(aloePrefab, "AloePool", 10, true, true, true);
        RumblePool = EZObjectPool.CreateObjectPool(rumblePrefab, "RumblePool", 10, true, true, true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
