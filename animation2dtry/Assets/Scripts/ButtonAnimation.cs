using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour {

	Animator animator;
	void Start () 
	{
		animator = GetComponent<Animator>();
	}

	public void Clicked()
	{
		animator.SetTrigger("Clicked");
	}
}
