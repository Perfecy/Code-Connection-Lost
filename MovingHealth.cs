using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(0, -100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.transform.position = new Vector3(980, 850, 0);
        }
    }
}
