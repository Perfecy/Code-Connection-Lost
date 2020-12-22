using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoScript : MonoBehaviour
{
   

    public void Cut(Collider2D collision)
    {

           Destroy(gameObject);
            
    }
}
