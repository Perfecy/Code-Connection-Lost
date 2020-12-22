using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gwl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.GetComponent<PlayerStats>().connectionLoss);
            if (collision.GetComponent<PlayerStats>().connectionLoss > 10)
            {
                System.Random rnd = new System.Random();
                if (rnd.Next(0, 10) > 3)
                {
                    Instantiate(gwl, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                Destroy(gameObject.GetComponent<GolemSpawn>());
            }
        
          //  Destroy(gameObject);
        }

    }
}
