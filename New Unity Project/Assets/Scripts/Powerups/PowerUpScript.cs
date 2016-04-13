using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	int pUpType = 1;
	[HideInInspector]
	public float pHealthMod = 1;
	[HideInInspector]
	public float pMoveMod = 1.0f;
	[HideInInspector]
	public GameObject ballTarget = null;
	[HideInInspector]
	public float bSpeedMod = 1.0f;
	[HideInInspector]
	public float bSizeMod = 1.0f;
	[HideInInspector]
	public float dodgeCoolDownMod = 0;


	public float lifeTimer = 15.0f;

	enum POWERUPTYPE
	{
		PLAYERSPEED,    //0
		BALLSIZE,   //2
					//BALLSPEED,		//1
	};

	POWERUPTYPE ePUpType;
	// Use this for initialization
	void Start()
	{
		pUpType = Random.Range(1, 3);
		transform.tag = "PowerUp";
		lifeTimer = 10.0f;
		Debug.Log(pUpType);
	}

	// Update is called once per frame
	void Update()
	{
		switch (pUpType)
		{
			case 1: //playerspeed modifier
				pMoveMod = 2.0f;
				ePUpType = POWERUPTYPE.PLAYERSPEED;
				break;
			case 2: //ball throw speed
				bSizeMod = 2.0f;
				ePUpType = POWERUPTYPE.BALLSIZE;
				break;
			//case 3:
			//	bSpeedMod = 2.0f;
			//	ePUpType = POWERUPTYPE.BALLSPEED;
			//	break;
			default:
				break;

		}

		lifeTimer -= Time.deltaTime;

		if (lifeTimer <= 0)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "ground")
		{
			gameObject.GetComponent<Rigidbody>().AddForce(0, 1.5f, 0, ForceMode.Impulse);
		}

		if (col.gameObject.tag == "Player")
		{
			if (!col.gameObject.GetComponent<PlayerMovementScript>().pUpActive && !col.gameObject.GetComponent<Shooting>().pUpActive)
			{
				switch (ePUpType)
				{
					case POWERUPTYPE.PLAYERSPEED:
						col.gameObject.GetComponent<PlayerMovementScript>().movementSpeed *= pMoveMod;
						col.gameObject.GetComponent<PlayerMovementScript>().pUpActive = true;
						break;
					case POWERUPTYPE.BALLSIZE:
						col.gameObject.GetComponent<Shooting>().scaleMod = bSizeMod;
						col.gameObject.GetComponent<Shooting>().pUpActive = true;
						break;
						//case POWERUPTYPE.BALLSPEED:
						//	break;
				}
				Destroy(gameObject);
			}
		}
	}
}

