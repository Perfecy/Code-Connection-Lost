using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyStats : MonoBehaviour
{
    public int hp;
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            hp -= 1;
        }

        if (hp <= 0)
        {
            Death();
        }
        
    }



    public void Death()
    {
        anim.SetBool("Death", true);
    }
}
