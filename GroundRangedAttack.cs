using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRangedAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Transform ShootPoint;
    private Transform playerX;
    private int bulletSpeed = 10;
    void Start()
    {
        playerX = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(bullet, ShootPoint.position, Quaternion.identity);
        //BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        BulletIns.GetComponent<Rigidbody2D>().velocity = -ShootPoint.right.normalized * bulletSpeed;

    }
}
