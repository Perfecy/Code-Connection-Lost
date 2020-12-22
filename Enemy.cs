using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;
public class Enemy : MonoBehaviour {

	public int health;
	private Rigidbody2D rb;
	public int armor;
	public GameObject deathEffect;
	public GameObject[] lootDrop;
	private	Enemy_behaviour eb;
	public int healthLeft;
	public GameObject hb;
	public GameObject hz;
	public GameObject ta;
	public GameObject hbb;
	private Transform playerPos;
	private GameObject player;
	private GameObject lootManager;
	public GameObject hpBar;
	//
	[SerializeField]
    public Transform pfFloatingDamage;

	private FloatingDamage floatingDamage;
	//
	private int incomeDamage;
	private int incomeType;

	private int ticks;
	float basic;
	float animSpeed;
	public bool affected;

	public AudioSource audio;
	private GameObject healthbar;

	

	public void Start()
    {
		//Debug.Log(ta.name);
		//Debug.Log(hz.name);
		if (GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>().current_level > 0)
		{
			health = math.abs(Convert.ToInt32(Convert.ToSingle(health) * (Convert.ToSingle(GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>().current_level) * 0.125f+1)));
		}
		healthLeft = health;
		player = GameObject.FindGameObjectWithTag("Player");
		playerPos = player.transform;
		rb = gameObject.GetComponent<Rigidbody2D>();
		basic = gameObject.GetComponent<Enemy_behaviour>().speed;
		animSpeed = gameObject.GetComponent<Animator>().speed;
		lootManager = GameObject.Find("GameManager");
		healthbar = GameObject.Find("Canvas").transform.GetChild(10).gameObject;
		healthbar.transform.position = new Vector3(-1000, -1000, 0);
		affected = false;
	}


	public void TakeDamage (int damage, int type)
	{
		incomeDamage = damage;
		incomeType = type;
		affected = true;
		healthbar.transform.position = new Vector3(980, 850, 0);
		gameObject.GetComponent<MobHealthBar>().hurt = true;
		if (type == 1)
        {
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(107, 255, 100, 255);
			Debug.Log("Switch to affected");
            InvokeRepeating("Poisoned", 0.1f, 0.75f);
			audio.Play(1);
		}
        else if(type == 2)
        {
			healthLeft -= incomeDamage * 3 / 4;
			Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
			floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
			floatingDamage.Setup(incomeDamage *3 / 4, incomeType);
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(112, 198, 255, 255);
			gameObject.GetComponent<Animator>().speed = animSpeed * 0.5f;
			gameObject.GetComponent<Enemy_behaviour>().speed = basic * 0.5f;
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
			InvokeRepeating("Burning", 0.25f, 0.75f);
			audio.Play(1);
		}
		else if (type == 4)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(220, 117, 255, 255);
			InvokeRepeating("Cursed", 0.01f, 0.75f);
			audio.Play(1);
		}
		rb.velocity = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y).normalized*2;// * speed ector2.positiveInfinity
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
		healthbar.transform.position = new Vector3(980, 850, 0);
		Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
		gameObject.GetComponent<MobHealthBar>().hurt = true;
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
		rb.velocity = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y).normalized * 2;
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
			Debug.Log("Switch to not affected");
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			Die();
		}
		if (ticks == 5)
		{
			affected = false;
			Debug.Log("Switch to not affected");
			CancelInvoke();
			ticks = 0;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
		}
		//rb.velocity = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y).normalized * 2;
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
		//rb.velocity = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y).normalized * 2;
	}

	private void Burning()
	{
		healthLeft -= Convert.ToInt32((float)incomeDamage / 8f);
		Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
		floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
		floatingDamage.Setup(Convert.ToInt32((float)incomeDamage / 8f), incomeType);
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
		//rb.velocity = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y).normalized * 2;
	}

	private void Cursed()
	{
		if (player.GetComponent<PlayerStats>().healthLoss >= Convert.ToInt32((float)incomeDamage / 5f))
		{
			player.GetComponent<PlayerStats>().healthLoss -= Convert.ToInt32((float)incomeDamage / 5f);
		}
		else
		{
			player.GetComponent<PlayerStats>().healthLoss = 0;

		}
		healthLeft -= Convert.ToInt32((float)incomeDamage / 5f);
		Transform damagePupupTransform = Instantiate(pfFloatingDamage, gameObject.transform.position + (transform.up * 0.5f), Quaternion.identity);
		floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
		floatingDamage.Setup(Convert.ToInt32((float)incomeDamage / 5f), incomeType);
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

	void Die ()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		//Destroy(gameObject);
		healthbar.transform.position = new Vector3(0, -1000, 0);
		gameObject.GetComponent<MobHealthBar>().hurt = false;
		gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		if (gameObject.TryGetComponent<CircleCollider2D>(out CircleCollider2D collider2D) == true)
		{
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
		}
		
		gameObject.GetComponent<Animator>().SetBool("Death", true);
		
		eb= gameObject.GetComponent<Enemy_behaviour>();
		player.GetComponent<PlayerStats>().connectionLoss -= 3;
		Destroy(rb);
		Destroy(eb);
		Destroy(hb);
		Destroy(hbb);
		Destroy(hz);
		Destroy(ta);
		Destroy(hpBar);
		//Instantiate(lootManager.GetComponent<LootManager>().GetRandomItem(), transform.position + (transform.right * -0.5f), Quaternion.identity);
		int ch = 0;
		while (ch == 0)
		{
			Instantiate(lootManager.GetComponent<LootManager>().GetItemForEnemy(), transform.position + (transform.right * -0.5f), Quaternion.identity);
			ch++;
		}
		Destroy(this);
	}

}
