using UnityEngine;
using InControl;

public class Shooting : MonoBehaviour
{
	/*
	Invincibility
	Ricochet ball
	Homo ball
	Speed
	ELEPHANTITIS Balls!

		Move speed
		Health pickup
		
	*/
	InputDevice input;
	public GameObject ball;
	public GameObject rightHand;

	public int ammo = 1;
	public int ballSpeed = 100;

	public float chargeUpTimer = 4;
	private float chargeUpCounter = 0;
	
	bool holdingRight = false;

	private GameObject rightBall;

	private Transform playerTransform;
	private BoxCollider bc;

	// Use this for initialization
	void Start ()
	{
		playerTransform = GetComponentInParent<Transform>();
		input = GetComponent<PlayerMovementScript>().input;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!holdingRight) // If not holding in one hand, check to see if we should be
			HoldBalls();
		if (rightBall != null)
			rightBall.transform.position = rightHand.transform.position;

		Throw();
		Block();
		DropBall();
	}

	void HoldBalls()
	{
		if (ammo > 0 && !holdingRight)
		{
			rightBall = Instantiate(ball, rightHand.transform.position, Quaternion.identity) as GameObject;
			rightBall.GetComponent<Rigidbody>().useGravity = false;
			rightBall.tag = "Ball";
			holdingRight = true;
			ammo--;
		}
	}

	void Throw()
	{
		if (holdingRight && input.RightTrigger.IsPressed)
		{
			if (chargeUpCounter < chargeUpTimer)
				chargeUpCounter += Time.deltaTime;
		}
		// On right/left trigger press
		// If ball in hand
		// Throw (apply force) in players forward direction
		if (holdingRight && input.RightTrigger.WasReleased)
		{
			rightBall.GetComponent<Rigidbody>().useGravity = true;
			rightBall.GetComponent<Rigidbody>().AddForce(playerTransform.forward * ballSpeed * (chargeUpCounter * 0.1f) * 5, ForceMode.Impulse);
			holdingRight = false;
			chargeUpCounter = 0;
			rightBall = null;
		}
	}
	
	void Block()
	{
	 // If left/right bumper pressed
		if (input.RightBumper.WasPressed)
		{
		//  Move hand to block/catch position
			// If ball collides with front of player
			if (ammo == 0 && !holdingRight)
			{
				// Catch
				ammo++;
			}
			else
			{
				// Block
			}
			
		}
	}

	void DropBall()
	{
		if (input.Action2.IsPressed && holdingRight)
		{
			rightBall.GetComponent<Rigidbody>().useGravity = true;
			holdingRight = false;
			rightBall = null;
		}
	}

	void PushBack()
	{
		if (input.Action3.WasPressed)
		{
			// Spawn box collider infront of Player to hit

		}
	}
}
