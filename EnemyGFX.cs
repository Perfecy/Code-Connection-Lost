using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using System.Security.Cryptography;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Transform playerPos;

    // Update is called once per frame
    private void Start()
    {
        //aiPath = GetComponentInParent<AIPath>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > playerPos.position.x)
        {
            rotation.y = 0;
            
        }
        else
        {
            
            rotation.y = 180;
        }


        transform.eulerAngles = rotation;
    }
}
