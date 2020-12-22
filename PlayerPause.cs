using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Paused", true);
        animator.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        animator.GetComponent<PlayerMovement>().enabled = false;
        animator.GetComponent<PlayerAttack>().enabled = false;
        animator.GetComponent<Weapon>().enabled = false;
        animator.GetComponent<PlayerStats>().enabled = false;
        animator.GetComponent<CharacterStatsystem>().enabled = false;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerMovement>().enabled = true;
        animator.GetComponent<PlayerAttack>().enabled = true;
        animator.GetComponent<Weapon>().enabled = true;
        animator.GetComponent<PlayerStats>().enabled = true;
        animator.GetComponent<CharacterStatsystem>().enabled = true;
        animator.SetBool("Paused", false);
      
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
