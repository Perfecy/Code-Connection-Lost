using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental_behaviour : MonoBehaviour
{
    #region Public Variables

   
    public float attackDistance; //Minimum distance for attack
    private float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public float speed;
    public GameObject player;
    public float sneerDistance;
    public float distance;
    public bool cooldown;
    public GameObject bullet;
    public Transform ShootPoint;
    public float bulletSpeed = 5f;
    public GameObject pike;
    public GameObject rock;
    public int pikeRow=5;
    public float step=1.5f;
 
    #endregion

    #region Private Variables

    private Animator anim;
    //Store the distance b/w enemy and player
    private bool attackMode;
    //Check if Player is in range
  //Check if Enemy is cooling after attack
    private float intTimer;
    private Transform playerPos;
    private bool sneered=true;
    private Vector3 rockPos;
    private float pikecd=0.3f;
    private int pikeCounter;
    private Vector3 pikePos;
    private bool isLeft;
    private float pikeStep;
    #endregion

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
        moveSpeed = speed;
        //  leftLimit.position = spawn.position + new Vector3(5,1,0);
        //rightLimit.position = spawn.position - new Vector3(5, 1, 0);
        playerPos = player.transform;
        
        //Debug.Log(GetComponents<Component>());
        //foreach(Component comp in GetComponents<Component>())
        //{
        //    //Type type = comp.GetType();
        //    //(comp as MonoBehaviour).enabled = false;
            
        //}
      
    }

    void Update()
    {
        Flip();
        distance = Vector2.Distance(transform.position, playerPos.position);

        //if (pikecd > 0)
        //{
        //    pikecd -= Time.deltaTime;
        //}

        //if (sneerDistance >= distance && sneered)
        //{
        //    anim.SetTrigger("SneerTrigger");
        //    sneered = false;
        //}

        if (pikeCounter >= pikeRow)
        {
            Debug.Log("OOPS");
            StopAllCoroutines();
            pikeCounter = 0;
        }
        if (isLeft)
        {
            pikeStep=-step;
        }
        if (!isLeft)
        {
            pikeStep=step;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            cooldown = false;
        }
        //if (attackDistance <= distance)
        //{
        //    anim.SetBool("canWalk", true);
        //    moveSpeed = speed;
        //}
        //else
        //{
        //    anim.SetBool("canWalk", false);
        //    //EnemyLogic();
        //    moveSpeed = 0f;
        //}


    }





    void Attack()
    {
        //timer = intTimer; //Reset Timer when Player enter Attack Range
        if (timer <= 0)
        {
            attackMode = true; //To check if Enemy can still attack or not

            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", true);
        }


    }





    public void TriggerCooling()
    {
        cooldown = true;
        timer = intTimer;

    }


    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > playerPos.position.x)
        {
            rotation.y = 180;
            isLeft = true;
        }
        else
        {
            isLeft = false;
            rotation.y = 0;
        }

        //Ternary Operator
        //rotation.y = (currentTarget.position.x < transform.position.x) ? rotation.y = 180f : rotation.y = 0f;

        transform.eulerAngles = rotation;
    }

    public void Shoot()
    {
        Vector2 targetPos = playerPos.position;

        Vector2 Direction = targetPos - (Vector2)transform.position;
        GameObject BulletIns = Instantiate(bullet, ShootPoint.position, Quaternion.identity);
        //BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        BulletIns.GetComponent<Rigidbody2D>().velocity = new Vector2(Direction.x, Direction.y).normalized * bulletSpeed;
        //BulletIns.GetComponent<Rigidbody2D>().velocity = -ShootPoint.right.normalized * bulletSpeed;

    }

    public void PikeAttack()
    {
        pikePos = transform.position;
        pikePos.y -=1.8f;
        pikePos.x = transform.position.x+pikeStep;
        pikeCounter = 0;
        StartCoroutine(PikeCoroutine());
    }

    public void RockAttack()
    {
        rockPos = playerPos.position;
        rockPos.y = playerPos.position.y + 5;
        Instantiate(rock, rockPos, Quaternion.identity);
    }

    IEnumerator PikeCoroutine()
    {
       // print(isLeft);
        while (true)
        {
            yield return new WaitForSeconds(pikecd);
            Instantiate(pike, pikePos, Quaternion.identity);
            pikePos.x = pikePos.x +pikeStep;
            pikeCounter++;
          
        }
    }
}
