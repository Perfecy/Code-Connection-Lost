using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingAttack : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    private Transform playerPos;
    public bool shotAllowed = false;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;


    }

    // Update is called once per frame
    void Update()
    {
        if (shotAllowed)
        {
            if (timeBtwShots <= 0)
            {
                GetComponent<Animator>().SetTrigger("Attack");    
                Instantiate(projectile, transform.position, gameObject.transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

        }
    }
}
