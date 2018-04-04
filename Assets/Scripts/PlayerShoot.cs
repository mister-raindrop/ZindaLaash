using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    private float timer = 0.2f;
    public float timeBetweenShots = 0.2f;
    public float playerDamageToZombies = 30f;
    public float playerDamageToMinions = 90f;
    public ParticleSystem muzzleEffect;
    public ParticleSystem bloodSplatter;
    public ParticleSystem tileHitEffect;
    private GameObject player;
    private Vector3 lookPos;
    private Animator anim;
    public Transform gun;
    private Transform originalGunPos;
    private AudioSource gunShot;
    public Texture2D cursorTex;
       
	// Use this for initialization
	void Start () {
        Cursor.SetCursor(cursorTex, new Vector2(cursorTex.width/2f, cursorTex.height/2f), CursorMode.Auto);
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        originalGunPos = gun;
        gunShot = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenShots && player.GetComponent<PlayerHealth>().playerHealth > 0) {
            Debug.Log("fired");
            Shoot();
        }
	}

    private void Shoot() {
        timer = 0;
       
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f)) {
            if (hit.collider.CompareTag("Tile")) {
                gunShot.Play();
                Debug.Log("hit");
                tileHitEffect.Stop(true);
                tileHitEffect.transform.position = hit.point;
                tileHitEffect.Play(true);
                
                hit.collider.GetComponent<TileStuff>().DestroyTile();
                StartCoroutine(hit.collider.GetComponent<TileStuff>().Reappear());
            }


            if (hit.collider.CompareTag("Zombie")) {
                hit.collider.GetComponent<ZombieHealth>().zombieTakeDamage(playerDamageToZombies);
                Debug.Log("Zombie hit");
                gunShot.Play();
                bloodSplatter.Stop(true);
                bloodSplatter.transform.position = hit.point;
                bloodSplatter.Play(true);
            }


            if (hit.collider.CompareTag("Minion")) {
                hit.collider.GetComponent<MinionHealth>().minionTakeDamage(playerDamageToMinions);
                Debug.Log("Minion hit");
                gunShot.Play();
                bloodSplatter.Stop(true);
                bloodSplatter.transform.position = hit.point;
                bloodSplatter.Play(true);
            }


            lookPos = new Vector3(hit.transform.position.x, player.transform.position.y, hit.transform.position.z);
            player.transform.LookAt(lookPos);
            //gun.rotation = Quaternion.LookRotation(lookPos - gun.position);
        }

        muzzleEffect.Play(true);
    }
}
