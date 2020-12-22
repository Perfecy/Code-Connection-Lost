using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecrScel : MonoBehaviour
{

	public int health;
	private Rigidbody2D rb;
	public int armor;
	public GameObject deathEffect;
	public GameObject[] lootDrop;
	private Enemy_behaviour eb;
	public int healthLeft;
	public GameObject hb;
	public GameObject hz;
	public GameObject ta;
	public GameObject hbb;
	private Transform playerPos;
	private GameObject player;
	private GameObject lootManager;
	NecrBehaviour nb;
	//
	[SerializeField]
    public Transform pfFloatingDamage;
	Animator NecrAnim;

	private FloatingDamage floatingDamage;

	private int incomeDamage;
	private int incomeType;

	private int ticks;
	float basic;
	float animSpeed;

	public bool affected;
	//

	public void Start()
	{
		healthLeft = health;
		
		rb = gameObject.GetComponent<Rigidbody2D>();
		lootManager = GameObject.Find("GameManager");
		nb = GameObject.Find("Necrophos").GetComponent<NecrBehaviour>();
		NecrAnim = nb.GetComponent<Animator>();

		player = GameObject.FindGameObjectWithTag("Player");
		playerPos = player.transform;
		basic = gameObject.GetComponent<Enemy_behaviour>().speed;
		animSpeed = gameObject.GetComponent<Animator>().speed;
	}

	private void Update()
	{
		
		if (NecrAnim.GetBool("Death"))
		{
			Die();
		}
	}
	public void TakeDamage(int damage, int type)
	{
		//healthLeft -= damage;
		incomeDamage = damage;
		incomeType = type;
		affected = true;
		if (type == 0)
		{
			healthLeft -= incomeDamage;
			Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
			floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
			floatingDamage.Setup(incomeDamage, incomeType);
		}
		else if (type == 1)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(107, 255, 100, 255);
			InvokeRepeating("Poisoned", 0.1f, 0.75f);
		}
		else if (type == 2)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(112, 198, 255, 255);
			gameObject.GetComponent<Animator>().speed = animSpeed * 0.5f;
			gameObject.GetComponent<Enemy_behaviour>().speed = basic * 0.5f;
			Debug.Log(animSpeed);
			InvokeRepeating("Freezed", 0.1f, 1f);
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
		}
		else if (type == 4)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(220, 117, 255, 255);
			InvokeRepeating("Cursed", 0.01f, 0.75f);
		}
		rb.velocity = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y).normalized * 2;// * speed ector2.positiveInfinity
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
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		//Destroy(gameObject);
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		if (gameObject.TryGetComponent<CircleCollider2D>(out CircleCollider2D collider2D) == true)
		{
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
		}

		gameObject.GetComponent<Animator>().SetBool("Death", true);

		eb = gameObject.GetComponent<Enemy_behaviour>();
		Destroy(rb);
		Destroy(eb);
		Destroy(hb);
		Destroy(hbb);
		Destroy(hz);
		Destroy(ta);
		nb.scelCount--;

	}
}