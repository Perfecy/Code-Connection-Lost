	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public CharacterStats characterStats;
	public float runSpeed = 40f;
	public float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	public GameObject dustPos;
	public GameObject dust;

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
            animator.SetBool("IsJumping", true);
			//Debug.Log(1);
		
		}



		if (Input.GetButton("Fire1"))
        {
			//animator.SetBool("Fire", true);
        }
        else
        {
			//animator.SetBool("Fire", false);

		}

    }

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
		animator.SetBool("CanJumpAttack", false);
		animator.ResetTrigger("Launch");
		animator.ResetTrigger("JumpAttack");

		Instantiate(dust, dustPos.transform.position, dustPos.transform.rotation);

		//Debug.Log(0);
	}

	public void SpeedBoost()
	{
	
		runSpeed =runSpeed * characterStats.speedBoost/2;
		
	}

	public void OnCrouching (bool isCrouching)
	{
	//	animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch , jump);
		jump = false;
	}
}
