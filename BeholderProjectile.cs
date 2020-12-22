using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderProjectile : MonoBehaviour
{
    public Transform playerPos;
    private Vector2 target;
    public Rigidbody2D rb;
    public int damage;
    Vector3 rotation;

    public float speed;
    void Start()
    {
        //rotation = transform.eulerAngles;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //target = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y);
        //rotation.y = (playerPos.position.x < transform.position.x) ? rotation.y = 180f : rotation.y = 0f;
        //rb.velocity = -target.normalized * speed;
        //transform.eulerAngles = rotation;

        Vector2 targetPos = playerPos.position;
        Vector2 Direction = targetPos - (Vector2)transform.position;
        float rotZ = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Direction.x, Direction.y).normalized * speed;

    }

    private void Update()
    {
        


    }
 

}
