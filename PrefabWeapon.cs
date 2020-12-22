using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	public CharacterStats characterStats;
	private float bulletDamage;
	public float cooldownTime= 0.5f;
	public float nextFireTime=0f;

	
	// Update is called once per frame
	void Update () {
		bulletDamage = bulletPrefab.GetComponent<Projectile>().damage;
		if(Time.time > nextFireTime)
		if (Input.GetButtonDown("Fire1"))
		{

			Shoot();
				nextFireTime = Time.time + cooldownTime;
		}
	}
	
	public void DamageBoost()
	{
		
		bulletPrefab.GetComponent<Projectile>().damage = (int)(bulletDamage * characterStats.getDamageAmplifire());

	}

	void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
