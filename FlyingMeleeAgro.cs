using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class FlyingMeleeAgro : MonoBehaviour
  {
   //Аффтарский код от Кирика
     
    public GameObject player;
    public float agroRange;
    public float disagroRange;
  //  public EnemyFlyingAttack efa;
    public float minDist;
    public GameObject spawn;
    private Animator animator;
   // public Enemy enemy;



    public bool Death= false;
    public bool Attacked;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //disagroRange = agroRange * 1.5f;

        if(Vector2.Distance(transform.position, spawn.transform.position) < 1 && Attacked)
        {
            Attacked = false;
            gameObject.GetComponent<AIPath>().maxSpeed = 5;
        }
        else if (Vector2.Distance(transform.position, player.transform.position) <= 1.7 )
        {
            Attacked = true;

        }
      
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float distToSpawn = Vector2.Distance(transform.position, spawn.transform.position);

        //Хардкод состояний, хз отрефакторю или нет
        if (Death)//Когда атаковал 
        {
            gameObject.GetComponent<AIPath>().maxSpeed = 0;
            gameObject.GetComponent<AIDestinationSetter>().target = spawn.transform;
            gameObject.GetComponent<AIPath>().canMove = false;
        }
        else if (Attacked)//Когда атаковал 
        {
            gameObject.GetComponent<AIPath>().maxSpeed = 7;
            gameObject.GetComponent<AIDestinationSetter>().target = spawn.transform;
            gameObject.GetComponent<AIPath>().canMove = true;
            animator.SetBool("Attack", false);
        }
        else if (distToPlayer < agroRange && distToPlayer > minDist && !Attacked)//Агро от гнезда
        {
            gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
            gameObject.GetComponent<AIPath>().canMove = true;
            //  gameObject.GetComponent<EnemyFlyingAttack>().shotAllowed = true;
            animator.SetBool("Attack", false);
        }
        else if (distToSpawn > disagroRange)//агро от игрока 
        {
            Attacked = true;
            gameObject.GetComponent<AIDestinationSetter>().target = spawn.transform;
            gameObject.GetComponent<AIPath>().canMove = true;
            // gameObject.GetComponent<EnemyFlyingAttack>().shotAllowed = false; ;
            animator.SetBool("Attack", false);
        }
        else if (minDist >= distToPlayer && !Attacked)//На расстоянии атаки 
        {
            gameObject.GetComponent<AIPath>().maxSpeed = 10;
            gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
            gameObject.GetComponent<AIPath>().canMove = true;
            //   gameObject.GetComponent<EnemyFlyingAttack>().shotAllowed = true;
            animator.SetBool("Attack",true);
        }
       
       
    }


    
}

