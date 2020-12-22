using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
   
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerStats>().TakeDamage(damage, transform);
                Destroy(gameObject);
            }
        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }

}
