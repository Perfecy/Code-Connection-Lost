using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    float stopTime=2;
    GameObject ta;
    GameObject hz;

    // Update is called once per frame
   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            stopTime = 1.3f;
            ta = collision.gameObject.GetComponent<Enemy_behaviour>().GetTA();
            hz = collision.gameObject.GetComponent<Enemy_behaviour>().GetHZ();
            //Debug.Log(ta);
            
           
            //  Debug.Log("AAAAAAAAAAAAAAA");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //    if (collision.gameObject.CompareTag("Enemy"))
        {

            if (stopTime >= 0)
            {
                stopTime -= Time.deltaTime;
            }
            if (stopTime <= 0)
            {
                hz.GetComponent<HotZone>().inRange = false;
                hz.SetActive(false);
                ta.SetActive(true);
                collision.gameObject.GetComponent<Enemy_behaviour>().inRange = false;
                collision.gameObject.GetComponent<Enemy_behaviour>().SelectTarget();
                collision.gameObject.GetComponent<Animator>().SetBool("Attack", false);
            }
        }

        //Debug.Log("HHHHHHHHHHHHHH");


    }
}
