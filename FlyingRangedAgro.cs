using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingRangedAgro : MonoBehaviour
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



    public bool Death = false;
    public bool Attacked;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        disagroRange = agroRange * 1.5f;

        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer < agroRange && distToPlayer > minDist)
        {
            gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
            gameObject.GetComponent<AIPath>().canMove = true;
            gameObject.GetComponent<EnemyFlyingAttack>().shotAllowed = true;
        }
        else if (distToPlayer > agroRange)
        {
            gameObject.GetComponent<AIDestinationSetter>().target = spawn.transform;
            gameObject.GetComponent<AIPath>().canMove = true;
            gameObject.GetComponent<EnemyFlyingAttack>().shotAllowed = false; ;
        }
        else if (minDist >= distToPlayer)
        {
            gameObject.GetComponent<AIPath>().canMove = false;
            gameObject.GetComponent<EnemyFlyingAttack>().shotAllowed = true;
        }



    }



}
