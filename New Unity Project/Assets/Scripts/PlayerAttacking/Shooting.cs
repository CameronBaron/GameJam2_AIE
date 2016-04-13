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
	public Transform rightHand;

	public int ammo = 1;
	public int ballSpeed = 100;

	public float chargeUpTimer = 4;
	private float chargeUpCounter = 0;
	
	bool holdingRight = false;

	private GameObject rightBall;

	private Transform playerTransform;
	private BoxCollider bc;

<<<<<<< HEAD
	private Animator anim;
=======
	//powerup things
	[HideInInspector]
	public float scaleMod = 1.0f;
	[HideInInspector]
	public bool pUpActive = false;
	float pUpTimer = 0.0f;
	float pUpMaxTime = 5;
>>>>>>> 4b8f6aa30d785329110415eb56fccc8bb189eeca

	// Use this for initialization
	void Start ()
	{
		gameObject.tag = "Player";
		playerTransform = GetComponentInParent<Transform>();
		input = GetComponent<PlayerMovementScript>().input;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!holdingRight) // If not holding in one hand, check to see if we should be
			HoldBalls();
		if (rightBall != null)
			rightBall.transform.position = rightHand.position;

		if (pUpActive)
		{
			pUpTimer += Time.deltaTime;
			if (pUpTimer > pUpMaxTime)
			{
				//reset values to default
				scaleMod = 1.0f;
				pUpTimer = 0;
				pUpActive = false;
			}
		}

		Throw();
		DropBall();
	}

	void HoldBalls()
	{
		if (ammo > 0 && !holdingRight)
		{
			rightBall = Instantiate(ball, rightHand.position, Quaternion.identity) as GameObject;
			rightBall.GetComponent<Rigidbody>().useGravity = false;
			rightBall.tag = "Ball";
			holdingRight = true;
			ammo--;
		}
	}

	void Throw()
	{
		if (input != null)
		{
<<<<<<< HEAD
			if (holdingRight && input.RightTrigger.IsPressed)
			{
				if (chargeUpCounter < chargeUpTimer)
					chargeUpCounter += Time.deltaTime;
			}

			// Throw (apply force) in players forward direction
			if (holdingRight && input.RightTrigger.WasReleased)
			{
				//if (anim.GetComponent<Animation>().Play())
				{
					rightBall.GetComponent<Rigidbody>().useGravity = true;
					rightBall.GetComponent<Rigidbody>().AddForce(playerTransform.forward * (ballSpeed + chargeUpCounter * 3), ForceMode.Impulse);
					holdingRight = false;
					chargeUpCounter = 0;
					rightBall = null;
				}
			}
=======
			rightBall.transform.localScale *= scaleMod;
			rightBall.GetComponent<Rigidbody>().useGravity = true;
			rightBall.GetComponent<Rigidbody>().AddForce(playerTransform.forward * (ballSpeed + chargeUpCounter * 3), ForceMode.Impulse);
			holdingRight = false;
			chargeUpCounter = 0;
			rightBall = null;
>>>>>>> 4b8f6aa30d785329110415eb56fccc8bb189eeca
		}
	}

	void DropBall()
	{
		if (input != null && (input.Action2.IsPressed && holdingRight))
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

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Ball")
		{
			if (input != null && input.RightBumper.IsPressed)
			{
				if (ammo == 0 && !holdingRight)
				{
					// Catch
					ammo++;
				}
			}
			else
			{				
				gameObject.GetComponent<HealthClass>().playerHealth -= col.gameObject.GetComponent<Ball>().damage;
			}
			//Destroy(col.gameObject);
		}
	}
}
