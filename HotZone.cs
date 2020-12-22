using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZone : MonoBehaviour
{
    private Enemy_behaviour enemyParent;
    public bool inRange;
    private Animator anim;
    public GameObject healthbar;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Enemy_behaviour>();
        anim = GetComponentInParent<Animator>();
        healthbar = GameObject.Find("Canvas").transform.GetChild(10).gameObject;

    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack") && !anim.GetBool("Death") )
        {
            enemyParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !anim.GetBool("Death"))
        {
            inRange = true;
            //Debug.Log("HotZoneEnter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& !anim.GetBool("Death"))
        {
            //Debug.Log("HotZoneLeft");
            
            //healthbar.transform.position = new Vector3(0, -1000, 0);
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
            anim.SetBool("Attack", false);
            healthbar.transform.position = new Vector3(0, -1000, 0);
            GetComponentInParent<MobHealthBar>().hurt = false;
        }
    }
}


