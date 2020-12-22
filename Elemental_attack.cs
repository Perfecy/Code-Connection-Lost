using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental_attack : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private Elemental_behaviour eb;
    public float shotDistance;
    public float punchDistance=2f;
    System.Random rnd;
    private int move;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rnd = new System.Random();
        eb = animator.GetComponent<Elemental_behaviour>();
        move=rnd.Next(0, 10);

        if (eb.distance <= 6)
        {
            if (move < 5)
            {
                animator.SetTrigger("AttackHeavy");
            }
            else
            {
                animator.SetTrigger("AttackPike");
            }
        }
        else
        {
            if (move < 5)
            {
                animator.SetTrigger("AttackShot");
            }
            else if(move<7)
            {
                animator.SetTrigger("AttackPike");
            }
            else
            {
                animator.SetTrigger("AttackHeavy");
            }
        }


        //if (move < 3)
        //{
        //    animator.SetTrigger("AttackHeavy");
        //}
        //else if(move < 5)
        //{
        //    animator.SetTrigger("AttackPike");
        //}
        //else
        //{
        //    animator.SetTrigger("AttackShot");
        //}
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
