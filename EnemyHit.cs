using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public int damage;
    int connection;
    private void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().connectionLoss >= 20)
            {
                collision.GetComponent<PlayerStats>().TakeDamage(damage*1.2f, gameObject.transform);
            }
            else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().connectionLoss >= 50)
            {
                collision.GetComponent<PlayerStats>().TakeDamage(damage * 1.3f, gameObject.transform);
            }
            else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().connectionLoss >= 75)
            {
                collision.GetComponent<PlayerStats>().TakeDamage(damage * 1.4f, gameObject.transform);
            }
            else
            {
                collision.GetComponent<PlayerStats>().TakeDamage(damage, gameObject.transform);
            }
        }
    }



}
