using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    public float fireRate = 0.5f;
    public GameObject bullet;
    public Transform spawnPoint;

    private AnimationManagerScript animManager;
    private CounteringScript counteringScript;
    private float shootTimer = 0;

    // Use this for initialization
    void Start () {
        animManager = GetComponent<AnimationManagerScript>();
        counteringScript = GetComponent<CounteringScript>();
	}
	
	// Update is called once per frame
	void Update () {
        shootTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && !counteringScript.IsCountering() && shootTimer > fireRate)
        {
            shootTimer = 0;
            animManager.Shoot();
            GameObject bulletInstance = GameObject.Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
        }
    }

    public float getShootTimer()
    {
        return shootTimer;
    }
}
