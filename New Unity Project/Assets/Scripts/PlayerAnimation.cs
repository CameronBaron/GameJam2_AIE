using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
	public Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// if key press
		//anim.Play("NAME_OF_ANIMATION", -1, 0f);
	}
}
