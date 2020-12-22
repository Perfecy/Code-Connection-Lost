using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    public int damage = 10;
    RaycastHit2D hit;
    bool fall = false;
    public int speed;
    public int treshold;

    System.Random rnd;
    void Start()
    {
        //  hit = Physics2D.Raycast(transform.position, Vector2.down*8);
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !TryGetComponent<CapsuleCollider2D>(out CapsuleCollider2D capsuleCollider2D))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage, gameObject.transform);
            Destroy(gameObject);
        }
        // System.Random rnd = new System.Random();
        if (collision.tag == "Player" && collision.GetComponent<PlayerStats>().connectionLoss >= 20 && rnd.Next(0, 100) > 20)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            Destroy(GetComponent<CapsuleCollider2D>());
           
            fall = true;
        }


        if (collision.gameObject.layer.Equals(8) && !TryGetComponent<CapsuleCollider2D>(out CapsuleCollider2D capsuleCollider2D1))
        {

            Destroy(gameObject);
        }


    }
}
