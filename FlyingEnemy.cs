using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

	public int health = 60;
	private Rigidbody2D rb;
	public int armor = 0;
	public GameObject deathEffect;
	public GameObject[] lootDrop;
	public int healthLeft;
	private Transform playerPos;
	private FlyingMeleeAgro fma;
	private bool dead = false;
	private CircleCollider2D[] carr;
	private GameObject player;
	public GameObject hpBar;
	[SerializeField]
	public Transform pfFloatingDamage;

	private FloatingDamage floatingDamage;
	//
	private int incomeDamage;
	private int incomeType;
	public AudioSource audio;
	private int ticks;
	float basic;
	float animSpeed;
	private FlyingRangedAgro fra;
	public bool affected;

	public void Start()
	{
		healthLeft = health;
		rb = gameObject.GetComponent<Rigidbody2D>();
		if(TryGetComponent<FlyingMeleeAgro>(out FlyingMeleeAgro flyingMeleeAgro)){
			fma = flyingMeleeAgro;
		}
		else if(TryGetComponent<FlyingRangedAgro>(out FlyingRangedAgro flyingRangedAgro))
		{
			fra = flyingRangedAgro;
		}

		player = GameObject.FindGameObjectWithTag("Player");
		playerPos = player.transform;
		rb = gameObject.GetComponent<Rigidbody2D>();
		animSpeed = GetComponent<Animator>().speed;
	}

	private void Update()
	{
		
		if (dead)
		{
			if (rb.velocity.magnitude <= 0.0001)
			{
				//Destroy(rb);
				//Destroy(GetComponentInChildren<CircleCollider2D>());
				
			}
		}
	}
	public void TakeDamage(int damage, int type)
	{
		incomeDamage = damage;
		incomeType = type;
		affected = true;
		if (type == 0)
		{
			healthLeft -= incomeDamage;
			Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
			floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
			floatingDamage.Setup(incomeDamage, incomeType);
			audio.Play(1);
		}
		else if (type == 1)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(107, 255, 100, 255);
			InvokeRepeating("Poisoned", 0.1f, 0.75f);
			audio.Play(1);
		}
		else if (type == 2)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(112, 198, 255, 255);
			gameObject.GetComponent<Animator>().speed = animSpeed * 0.5f;
			gameObject.GetComponent<Enemy_behaviour>().speed = basic * 0.5f;
			Debug.Log(animSpeed);
			InvokeRepeating("Freezed", 0.1f, 1f);
			audio.Play(1);
		}
		else if (type == 3)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 100, 100, 255);
			healthLeft -= incomeDamage / 2;
			Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
			floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
			floatingDamage.Setup(incomeDamage / 2, incomeType);
			Debug.Log(incomeDamage / 2);
			InvokeRepeating("Burning", 0.25f, 0.75f);
			audio.Play(1);
		}
		else if (type == 4)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(220, 117, 255, 255);
			InvokeRepeating("Cursed", 0.01f, 0.75f);
			audio.Play(1);
		}
		//rb.velocity = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y).normalized * 2;// * speed ector2.positiveInfinity
		if (healthLeft <= 0)
		{
			Die();
		}
		else if (healthLeft > 0)
		{
			gameObject.GetComponent<Animator>().SetTrigger("HurtTrigger");
		}
	}

	public void RawHit(int damage, int type)
	{
		healthLeft -= damage;
		audio.Play(1);
		Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
		floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
		floatingDamage.Setup(damage, type);
		if (healthLeft <= 0)
		{
			Die();
		}
		else if (healthLeft > 0)
		{
			gameObject.GetComponent<Animator>().SetTrigger("HurtTrigger");
		}
	}

	private void Poisoned()
	{
		healthLeft -= incomeDamage / 3;
		Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
		floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
		floatingDamage.Setup(incomeDamage / 3, incomeType);
		ticks += 1;
		if (healthLeft <= 0)
		{
			affected = false;
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			Die();
		}
		if (ticks == 5)
		{
			affected = false;
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
		}
	}

	private void Freezed()
	{
		ticks += 1;
		if (healthLeft <= 0)
		{
			affected = false;
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponent<Animator>().speed = animSpeed;
			gameObject.GetComponent<Enemy_behaviour>().speed = basic;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			Die();
		}
		if (ticks == 5)
		{
			affected = false;
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponent<Animator>().speed = animSpeed;
			gameObject.GetComponent<Enemy_behaviour>().speed = basic;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
		}
	}

	private void Burning()
	{
		healthLeft -= incomeDamage / 8;
		Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
		floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
		floatingDamage.Setup(incomeDamage / 8, incomeType);
		ticks += 1;
		if (healthLeft <= 0)
		{
			affected = false;
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			Die();
		}
		if (ticks == 4)
		{
			affected = false;
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
		}
	}

	private void Cursed()
	{
		if (player.GetComponent<PlayerStats>().healthLoss >= incomeDamage / 5)
		{
			player.GetComponent<PlayerStats>().healthLoss -= incomeDamage / 5;
		}
		else
		{
			player.GetComponent<PlayerStats>().healthLoss = 0;

		}
		healthLeft -= incomeDamage / 5;
		Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
		floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
		floatingDamage.Setup(incomeDamage / 5, incomeType);
		ticks += 1;
		if (healthLeft <= 0)
		{
			affected = false;
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			Die();
		}
		if (ticks == 5)
		{
			affected = false;
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
		}
	}

	void Die()
	{
		GameObject empty = new GameObject();
		System.Random rnd = new System.Random();
		
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		//Destroy(gameObject);
		if (fma != null)
		{
			fma.Death = true;
			Destroy(gameObject.GetComponent<FlyingMeleeAgro>());
		}
		if(fra != null)
		{
			Destroy(fra);
		}
		carr = gameObject.GetComponents<CircleCollider2D>();
		foreach (CircleCollider2D collider2D in carr)
		{
			collider2D.enabled = false;
		}
		if (TryGetComponent<EnemyFlyingAttack>(out EnemyFlyingAttack enemyFlyingAttack))
		{
			Destroy(enemyFlyingAttack);
		}
		dead = true;
		player.GetComponent<PlayerStats>().connectionLoss -= 3;
		//gameObject.GetComponent<CircleCollider2D>().enabled = false;
		rb.gravityScale = 1f;
		Destroy(gameObject.GetComponent<AIPath>());
		Destroy(hpBar);
		//Destroy(gameObject.GetComponent<FlyingMeleeAgro>());
		Destroy(gameObject.GetComponent<AIDestinationSetter>());
		gameObject.GetComponent<Animator>().SetBool("Death", true);
		//Destroy(rb);
		Debug.Log(gameObject.GetComponent<Animator>().GetBool("Death"));
		//Instantiate(lootDrop[0], transform.position + (transform.right * -0.5f), Quaternion.identity);
		//Instantiate(lootDrop[1], transform.position + (transform.right * 0.5f), Quaternion.identity);
		//Instantiate(lootDrop[2], transform.position, Quaternion.identity);
		Destroy(GetComponentInChildren<EnemyGFX>());
		Destroy(GetComponent<EnemyHit>());
		if (rnd.Next(0, 2)==1)
		{
            // Instantiate(GameObject.FindGameObjectWithTag("LM").GetComponent<LootManager>().GetItem(30), transform.position + (transform.right * -0.5f), Quaternion.identity);
		}
		
	}

}
