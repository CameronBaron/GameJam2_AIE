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
	InputDevice input { get; set; }
	public GameObject ball;
	public GameObject rightHand;

	public int ammo = 1;
	public int ballSpeed = 100;

	public float chargeUpTimer = 4;
	private float chargeUpCounter = 0;
	
	bool holdingRight = false;

	private GameObject rightBall;

	private Transform playerTransform;

	// Use this for initialization
	void Start ()
	{
		playerTransform = GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		input = InputManager.ActiveDevice;
		if (!holdingRight) // If not holding in one hand, check to see if we should be
			HoldBalls();

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
			chargeUpCounter += Time.deltaTime;
		}
		// On right/left trigger press
		// If ball in hand
		// Throw (apply force) in players forward direction
		if (holdingRight && input.RightTrigger.WasReleased)
		{
			rightBall.GetComponent<Rigidbody>().useGravity = true;
			rightBall.GetComponent<Rigidbody>().AddForce(playerTransform.forward * ballSpeed * chargeUpCounter * 5, ForceMode.Impulse);
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
			if (ammo == 0)
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
}
