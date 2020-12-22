using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    RaycastHit2D hit;
    bool fall= false;
    public int speed;
    System.Random rnd;
    public int connectionLoss;
    public AudioSource audio;
    void Start()
    {
        //  hit = Physics2D.Raycast(transform.position, Vector2.down*8);
         rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(hit.collider.tag);
        //if (hit.collider.tag == "Player")
        //{
        //    hit.rigidbody.velocity = Vector2.down * 2;
        //}

        // Debug.DrawRay(transform.position, Vector2.down*8, Color.green);
      //  Debug.Log(rnd.Next(0, 10));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !TryGetComponent<CapsuleCollider2D>(out CapsuleCollider2D capsuleCollider2D))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage, gameObject.transform);
        }
       // System.Random rnd = new System.Random();
        if (collision.tag == "Player" && collision.GetComponent<PlayerStats>().connectionLoss>= 35 && rnd.Next(0, 100) <50)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down *speed;
            audio.Play();
            Destroy(GetComponent<CapsuleCollider2D>());
            GetComponent<Animator>().SetBool("Fall", true);
            fall = true;
        }


        if(collision.gameObject.layer.Equals(8) && !TryGetComponent<CapsuleCollider2D>(out CapsuleCollider2D capsuleCollider2D1))
        {
            GetComponent<Animator>().SetBool("Hit", true);
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<BoxCollider2D>());
        }

      
    }


    public void Cut()
    {
        Destroy(gameObject);
    }
}
