using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class warning : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject whatToCheck;
    public int connectionLoss;
    ParticleSystem part;
    PlayerStats stats;
    public GameObject learning;
    int ch = 0;
    int kostyl = 0;
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleSystem>().Stop();
        part = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleSystem>();
        stats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerStats>();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    part = collision.GetComponentInChildren<ParticleSystem>();
    //    if (collision.CompareTag("Player"))
    //    {
    //        Debug.LogError(collision.name);
    //        if (collision.GetComponent<PlayerStats>().connectionLoss >= connectionLoss && ch == 0)
    //        {
    //            ch++;
    //            InvokeRepeating("Play", 0.1f, 0.85f);
    //            part.Play();

    //            Destroy(gameObject);
    //        }
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //part = collision.GetComponentInChildren<ParticleSystem>();
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerStats>().connectionLoss >= connectionLoss && ch == 0)
            {
              
               
                part.Play();
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            part.Stop();
        }

    }


    public void Play()
    {

        bool f = transform.GetComponentInParent<CheckZone>().flag;

        if (stats.particleLearner == 0)
        {
            //ShowLearning();
            stats.particleLearner += 1;
        }


        //part.Play();

        ch++;
        if (f)
        {
            
            part.Stop();
            CancelInvoke();
            Destroy(gameObject);
        }else if (ch >= 5)
        {
            part.Stop();
            CancelInvoke();
            Destroy(gameObject);
        }

    }

    public void ShowLearning()
    {
        learning.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Когда рядом опасное место, соединение нарушается и ты видишь такой эффект!");
        learning.SetActive(true);
        //InvokeRepeating("Costyl", 0.1f, 1f);
    }

    public void Costyl()
    {
        kostyl += 1;

        if (kostyl == 6)
        {
            kostyl = 0;
            learning.SetActive(false);
            CancelInvoke();
        }
    }

    

}
