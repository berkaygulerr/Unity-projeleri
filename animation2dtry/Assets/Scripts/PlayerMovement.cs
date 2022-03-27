using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Animator animator;
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	void Update () 
	{
		float horizontalMove = Input.GetAxis("Horizontal");
		float verticalMove = Input.GetAxis("Vertical");
		float jump = Input.GetAxis("Jump");

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if(horizontalMove < 0f)
		{
			transform.localScale = new Vector3(-1, 1, 0);
		}
		else if (horizontalMove > 0f)
		{
			transform.localScale = new Vector3(1, 1, 0);
		}

		if (jump > 0f)
		{
			animator.SetBool("IsJumping", true);
		}
		else
		{
			animator.SetBool("IsJumping", false);
		}
	}
}
