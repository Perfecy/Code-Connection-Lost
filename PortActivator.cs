using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortActivator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boss;
    public GameObject port;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<Animator>().GetBool("Death"))
        {
            port.SetActive(true);
        }

    }
}
