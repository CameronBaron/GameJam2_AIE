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

	public float lifeTimer = 15.0f;

	// Use this for initialization
	void Start ()
	{
		pUpType = Random.Range(1, 6);
		transform.tag = "PowerUp";
		lifeTimer = 10.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch(pUpType)
		{
			case 1: //Invincibility
				pHealthMod = Mathf.Infinity;
				Debug.Log("p health : " + pHealthMod);
				break;
			case 2: //Player Move Speed
				pMoveMod = 2.0f;
				Debug.Log("p move : " + pMoveMod);
				break;
			case 3: // Ball Target
				Debug.Log("b targ : " + ballTarget);
				break;
			case 4: // Ball Speed
				bSpeedMod = 2.0f;
				Debug.Log("b speed : " + bSpeedMod);
				break;
			case 5: // Ball Size Mod
				bSizeMod = 2.0f;
				Debug.Log("b size : " + bSizeMod);
				break;
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
	}

}
