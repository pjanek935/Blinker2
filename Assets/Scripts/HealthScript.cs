using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

    public int maxHealth = 100;
    public Image healthSlider;
    public Image bloodOverlay;

    private int currentHealth = 100;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.fillAmount = (currentHealth / (float)maxHealth);
        healthSlider.GetComponent<BlinkImage>().BlinkRed();
        bloodOverlay.GetComponent<BloodOverlayScript>().Blink();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Bullet")
            DealDamage(collision.other.gameObject.GetComponent<ShootBulletScript>().damage);
    }
}
