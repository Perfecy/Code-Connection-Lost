using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyGXF2 : MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target=GetComponentInParent<AIDestinationSetter>().target;
    }

    // Update is called once per frame
    void Update()
    {
        target = GetComponentInParent<AIDestinationSetter>().target;
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
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

