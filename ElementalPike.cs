using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalPike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void Hit()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
