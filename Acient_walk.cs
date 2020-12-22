using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acient_walk : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private AcientBehaviour ab;
    private Rigidbody2D rb;
    private Transform pos;
    private float moveSpeed = 6f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ab = animator.GetComponent<AcientBehaviour>();
        rb = animator.GetComponent<Rigidbody2D>();
        pos = ab.pos[ab.curPos % 4];
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Vector2 targetPosition = new Vector2(pos.position.x - rb.transform.position.x, pos.position.y - rb.transform.position.y);
        rb.transform.position = Vector2.MoveTowards(rb.transform.position, pos.position, moveSpeed * Time.deltaTime);
        //Debug.Log(pos.name);
        //Debug.Log(targetPosition.magnitude);
        if (new Vector2(pos.position.x - rb.transform.position.x, pos.position.y - rb.transform.position.y).magnitude < 0.1f)
        {
            animator.SetBool("Move", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        ab.AddPos();
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
