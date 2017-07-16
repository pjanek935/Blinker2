using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    public float fireRate = 0.5f;
    public GameObject bullet;
    public Transform spawnPoint;
    public Camera camera;

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

        RaycastHit hit;
        Vector3 rayDirection = camera.transform.forward;
        Ray ray = new Ray(camera.transform.position + rayDirection * 5, rayDirection);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(camera.transform.position, hit.point);
            Vector3 shootDirection = hit.point - spawnPoint.position;
            spawnPoint.rotation = Quaternion.LookRotation(shootDirection);
        }
        else
        {
            Vector3 shootDirection = camera.transform.position + rayDirection * 100000 - spawnPoint.position;
            spawnPoint.rotation = Quaternion.LookRotation(shootDirection);
        }

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
