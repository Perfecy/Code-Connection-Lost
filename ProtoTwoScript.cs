using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTwoScript : MonoBehaviour
{

    public GameObject platform;
    public void Cut(Collider2D collision)
    {


        

                platform.SetActive(true);
                Destroy(gameObject);
            
    }
}
