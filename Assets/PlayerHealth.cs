using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthScript
{
    public Image healthSlider;
    public Image bloodOverlay;

    // Use this for initialization
    void Start () {
        Init();
    }

    public override void DealDamage(int damage)
    {
        base.DealDamage(damage);

        healthSlider.fillAmount = (currentHealth / (float)maxHealth);
        healthSlider.GetComponent<BlinkImage>().BlinkRed();
        bloodOverlay.GetComponent<BloodOverlayScript>().Blink();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.tag, GlobalConst.DAMAGE_SPHERE))
        {
            DealDamage(GlobalConst.ENEMY_DAMAGE);
        }
    }

    public override void Death()
    {

    }
}
