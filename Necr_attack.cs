using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necr_attack : StateMachineBehaviour
{
    private NecrBehaviour nb;
    public float shotDistance;
    public float punchDistance = 3f;
    System.Random rnd;
    private int move;
    private bool acid=true;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rnd = new System.Random();
        nb = animator.GetComponent<NecrBehaviour>();
        move = rnd.Next(0, 10);
        if (animator.GetComponent<Boss>().healthLeft < (animator.GetComponent<Boss>().health/2) && acid)
        {
            animator.SetTrigger("Sneer");
            acid = false;
        }
        else if (nb.distance <= punchDistance)
        {
            animator.SetTrigger("AttackHit");
        }
        else if (nb.scelCount < 2 && move<3)
        {
            animator.SetTrigger("AttackScel");
            nb.scelCount++;

        }
        else if (nb.zombCount < 1 && move<5)
        {
            animator.SetTrigger("AttackZomb");
            nb.zombCount++;
        }
        else
        {
            animator.SetTrigger("AttackShot");
        }

        //if (animator.GetComponent<Boss>().healthLeft < animator.GetComponent<Boss>().health)
        //{

        //}
        //else
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
