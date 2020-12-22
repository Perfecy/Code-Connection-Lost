using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necr_walk : StateMachineBehaviour
{
    private Transform playerPos;
    private Rigidbody2D rb;
    private float moveSpeed;
    private NecrBehaviour nb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        moveSpeed = animator.GetComponent<NecrBehaviour>().speed;
        nb = animator.GetComponent<NecrBehaviour>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (nb.distance <= nb.attackDistance)
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

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
