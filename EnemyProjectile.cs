using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Transform playerPos;
    private Vector2 target;
    public Rigidbody2D rb;
    public float damage;
   
    public float speed;
    void Start()
    {
       
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
       
        //gameObject.transform.rotation = Quaternion.LookRotation(playerPos.position - transform.position);
        target = new Vector2(transform.position.x - playerPos.position.x,transform.position.y-  playerPos.position.y);
        
        rb.velocity =-target *  speed;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Enemy")
        {
            CharacterStats player = hitInfo.GetComponent<CharacterStats>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }


            Destroy(gameObject);
        }
    }

}
