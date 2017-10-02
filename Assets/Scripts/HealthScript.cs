using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public int maxHealth = 100;

    protected int currentHealth = 100;
    protected bool dead = false;

    public bool Dead
    {
        get { return dead; }
    }

    // Use this for initialization
    void Start()
    {
        Init();
    }

    protected void Init()
    {
        currentHealth = maxHealth;
    }

    public virtual void DealDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (!dead)
            {
                Death();
                dead = true;
            }
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            int damage = collision.gameObject.GetComponent<ShootBulletScript>().damage;
            DealDamage(damage);
        }
    }

    public virtual void Death()
    {

    }
}
