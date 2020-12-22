using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_behaviour : MonoBehaviour
{
    #region Public Variables
   
    public float rayCastLength;
    public float attackDistance; //Minimum distance for attack
    private float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform spawn;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    public float speed;
    #endregion

    #region Private Variables
   
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
   //Check if Player is in range
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    private bool stopMove=false;
    private float stopTime;
    private bool flag=true;
    private GameObject[] mas;
    private GameObject hz;
    private GameObject ta;
    private GameObject healthbar;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
        moveSpeed = speed;
        distance = 1000;
      
        if (TryGetComponent<NecrScel>(out NecrScel ns))
        {
            ta = ns.ta;
            hz = ns.hz;

        }
        else if (TryGetComponent<NecrZomb>(out NecrZomb nz))
        {
            ta = nz.ta;
            hz = nz.hz;
        }
        else
        {
            ta = transform.GetComponent<Enemy>().ta;
            hz = transform.GetComponent<Enemy>().hz;
        }

        
        
      //  leftLimit.position = spawn.position + new Vector3(5,1,0);
//rightLimit.position = spawn.position - new Vector3(5, 1, 0);
    }

    void Update()
    {
       // Debug.Log(GetComponentInChildren<TriggerArea>(true));

        if (!stopMove)
        {
          
            if (!attackMode)
            {
                Move();
            }

            if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
            {
                SelectTarget();
            }



            if (inRange)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
                {
                    Flip();
                }

                EnemyLogic();
            }

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (attackDistance <= distance)
            {
                anim.SetBool("canWalk", true);
                moveSpeed = speed;
            }
            else
            {
                anim.SetBool("canWalk", false);
                moveSpeed = 0f;
            }

        }
        else if (stopMove)
        {
           
            stopTime -= Time.deltaTime;
            anim.SetBool("Attack", false);
            anim.SetBool("canWalk", false);
            moveSpeed = 0f;
            if (stopTime <= 0)
            {
                stopMove = false;
            }
        }

      
    }

   

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
         if (cooling)
         {
            Cooldown();
            anim.SetBool("Attack", false);
         }
        if (distance > attackDistance )//&& !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

       
    }

    void Move()
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        //timer = intTimer; //Reset Timer when Player enter Attack Range
        if(timer <= 0)
        {
            attackMode = true; //To check if Enemy can still attack or not

            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", true);
        }
        
        
    }

    void Cooldown()
    {

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);

    }


    public void TriggerCooling()
    {
        cooling = true;
        timer = intTimer;
  
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector3.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector3.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        //Ternary Operator
        //target = distanceToLeft > distanceToRight ? leftLimit : rightLimit;

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x) 
        {
           
            rotation.y = 180;
            if (!flag)
            {
                stopTime = 0.5f;
                stopMove = true;
            }
            flag = true;
        }
        else
        {

            rotation.y = 0;
            if (flag)
            {
                stopTime = 0.5f;
                stopMove = true;
            }
            flag = false;
           
        }

        //Ternary Operator
        //rotation.y = (currentTarget.position.x < transform.position.x) ? rotation.y = 180f : rotation.y = 0f;

        transform.eulerAngles = rotation;
      
    }

    public GameObject GetTA()
    {
       
        return ta;
    }
    public GameObject GetHZ()
    {

        return hz;
    }


}
