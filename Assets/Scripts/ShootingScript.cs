using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    public float fireRate = 0.5f;
    public GameObject bullet;
    public Transform spawnPoint;

    private AnimationManagerScript animManager;
    private FPSMovementScript fpsMove;
    private CounteringScript counteringScript;
    private float nextFire = 0.0f;
    private float shootTimer = 0;

    // Use this for initialization
    void Start () {
        animManager = GetComponent<AnimationManagerScript>();
        counteringScript = GetComponent<CounteringScript>();
        fpsMove = GetComponent<FPSMovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
        shootTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && !counteringScript.isCountering() && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shootTimer = 0;
            animManager.Shoot();
            GameObject bulletInstance = GameObject.Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
            Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
            Vector3 additionalSpeed = new Vector3(fpsMove.getHorMove() * fpsMove.moveSpeed, 0, fpsMove.getVerMove() * fpsMove.moveSpeed);
           // bulletRb.velocity = bulletRb.velocity + additionalSpeed;
        }
    }

    public float getShootTimer()
    {
        return shootTimer;
    }
}
