using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    public float health = 100f;
    public float damageAmplifire = 1f;
    public float armour = 1f;
    public float speedBoost = 10f;
    
    public float getArmour()
    {
        return armour;
    }
    public float getHealth()
    {
        return health;
    }
    public float getDamageAmplifire()
    {
        return damageAmplifire;
    }

    public float getSpeedBoost()
    {
        return speedBoost;
    }


    public void TakeDamage(float damage)
    {
        health -= damage/armour;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(health);
        }
    }
}
