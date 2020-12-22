using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalRock : MonoBehaviour
{
    public Rigidbody2D rb;
    public float delay = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay - Time.deltaTime;
        if (delay <= 0)
        {
            rb.gravityScale = 4f;
        }
    }
}
