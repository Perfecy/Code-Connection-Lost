using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	CharacterStatsystem cs;
    public float speed = 20f;
	public int damage;
	public Rigidbody2D rb;
	public GameObject impactEffect;
	private Enemy enemy;
	private FlyingEnemy flyingEnemy;
	public int type;

	int checker = 0;

	// Use this for initialization
	void Start () {

        rb.velocity = transform.right * speed;
		GameObject player = GameObject.Find("PlayerViking");
		cs = player.GetComponent<CharacterStatsystem>();

		if (type == 0)
		{
			damage = cs.damage.GetValue(); //беру дамаг из статов плеера
		}
		else if (type == 1)
		{
			damage = cs.poisonDamage.GetValue(); //беру дамаг из статов плеера
		}
		else if (type == 2)
		{
			damage = cs.frostDamage.GetValue(); //беру дамаг из статов плеера
		}
		else if (type == 3)
		{
			damage = cs.fireDamage.GetValue(); //беру дамаг из статов плеера
		}
		else if (type == 4)
		{
			damage = cs.shadowDamage.GetValue(); //беру дамаг из статов плеера
		}
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		if (checker == 0) //триггер срабатывает дважды почему-то, поэтому надо чекать
        {
			if (hitInfo.TryGetComponent<Enemy>(out Enemy enemy) == true)
			{
				checker += 1;
				if(type == 0)
				{
					hitInfo.GetComponent<Enemy>().RawHit(damage, type);
				}
				else
				{
					hitInfo.GetComponent<Enemy>().TakeDamage(damage, type);
				}
				
			}
			else if (hitInfo.TryGetComponent<FlyingEnemy>(out FlyingEnemy flyingEnemy) == true)
			{
				checker += 1;
				if (type == 0)
				{
					hitInfo.GetComponent<FlyingEnemy>().RawHit(damage, type);
				}
				else
				{
					hitInfo.GetComponent<FlyingEnemy>().TakeDamage(damage, type);
				}
			}
			else if (hitInfo.TryGetComponent<NecrScel>(out NecrScel necrScel) == true)
			{
				checker += 1;
				if (type == 0)
				{
					hitInfo.GetComponent<NecrScel>().RawHit(damage, type);
				}
				else
				{
					hitInfo.GetComponent<NecrScel>().TakeDamage(damage, type);
				}
			}
			else if (hitInfo.TryGetComponent<Boss>(out Boss boss) == true)
			{
				checker += 1;
				if (type == 0)
				{
					hitInfo.GetComponent<Boss>().RawHit(damage, type);
				}
				else
				{
					hitInfo.GetComponent<Boss>().TakeDamage(damage, type);
				}
			}
			else if (hitInfo.TryGetComponent<NecrZomb>(out NecrZomb necrZomb) == true)
			{
				checker += 1;
				if (type == 0)
				{
					hitInfo.GetComponent<NecrZomb>().RawHit(damage, type);
				}
				else
				{
					hitInfo.GetComponent<NecrZomb>().TakeDamage(damage, type);
				}

			}

		}

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
	
}
