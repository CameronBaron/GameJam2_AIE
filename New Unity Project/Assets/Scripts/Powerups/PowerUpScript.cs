using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	int pUpType = 1;

	public float pHealthMod = 1;
	public float pMoveMod = 1.0f;
	public GameObject ballTarget = null;
	public float bSpeedMod = 1.0f;
	public float bSizeMod = 1.0f;

	// Use this for initialization
	void Start ()
	{
		pUpType = Random.Range(1, 6);
		transform.tag = "PowerUp";
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
	}

	//void OnCollisionEnter(Collision col)
	//{
	//	if(col.gameObject.tag == "Player")
	//	{
	//		// Pass vars to Player
	//		// Player Health
	//		// Player move speed
	//		// 
	//		// 
	//		// 
	//		// Ball Target
	//		// Ball Speed
	//		// Ball Size Mod
	//		// 

	//		Destroy(gameObject);
	//	}
	//}

}
