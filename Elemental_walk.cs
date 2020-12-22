using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental_walk : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private Transform playerPos;
    private Rigidbody2D rb;
    private float moveSpeed;
    private Elemental_behaviour eb;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        moveSpeed = animator.GetComponent<Elemental_behaviour>().speed;
        eb = animator.GetComponent<Elemental_behaviour>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (eb.distance <= eb.attackDistance)
        {
            animator.SetBool("canWalk", false);
        }
        Vector2 targetPosition = new Vector2(playerPos.position.x, rb.transform.position.y);

        rb.transform.position = Vector2.MoveTowards(rb.transform.position, targetPosition, moveSpeed * Time.deltaTime);


        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
