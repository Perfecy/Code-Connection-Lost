using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckZone : MonoBehaviour
{
    public GameObject whatToCheck;
    public int connectionLoss;
    ParticleSystem part;
    int ch = 0;
    public bool flag = false;
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleSystem>().Stop();
        part = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  part = collision.GetComponentInChildren<ParticleSystem>();
        if (collision.CompareTag("Player"))
        {
            //Debug.LogError(collision.name);
            if (collision.GetComponent<PlayerStats>().connectionLoss >= connectionLoss && ch ==0 )
            {
                //ch++;
                //InvokeRepeating("Play", 0.1f, 0.85f);
                //part.Play();
                if (whatToCheck.TryGetComponent<ProtoScript>(out ProtoScript protoScript))
                {
                    flag = true;
                    protoScript.Cut(collision);
                }
                if (whatToCheck.TryGetComponent<ProtoTwoScript>(out ProtoTwoScript protoTwoScript))
                {
                    flag = true;
                    protoTwoScript.Cut(collision);
                }

                Destroy(gameObject);
            }
        }
    }

    public void Play()
    {
        //part.Play();
        ch++;
        if (ch >= 3)
        {
            part.Stop();
            CancelInvoke();
            Destroy(gameObject);
        }
    }
}
