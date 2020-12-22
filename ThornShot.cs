using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornShot : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerPos;
    public float speed;
    void Start()
    {
        Vector3 rotation = transform.eulerAngles;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (transform.position.x > playerPos.position.x)
        {
            rotation.y = 0;
            
        }
        else
        {
            
            rotation.y = 180;
        }
        transform.eulerAngles = rotation;
        GetComponent<Rigidbody2D>().velocity =new Vector2(playerPos.position.x-transform.position.x,0).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
