using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof (NavMeshAgent))]

public class EnemyAI : MonoBehaviour
{
	// Movement //
	[SerializeField]
	private float movementSpeed;


	// Targeting Vars //
	private GameObject[] players;
	private GameObject closestPlayer;
	private float distToClostestPlayer = Mathf.Infinity;
	private GameObject[] balls;
	private GameObject closestBall;
	private float distToClostestBall = Mathf.Infinity;
	Vector3 myPos;

	// Use this for initialization
	void Start ()
	{
		players = GameObject.FindGameObjectsWithTag("Player");
		balls = GameObject.FindGameObjectsWithTag("Ball");
	}
	
	// Update is called once per frame
	void Update ()
	{
		myPos = transform.position;
	}

	void FindClosestPlayer()
	{
		foreach (GameObject go in players)
		{
			Vector3 dist = go.transform.position - myPos;
			float curDistance = dist.sqrMagnitude;
			if (curDistance < distToClostestPlayer)
			{
				closestPlayer = go;
				distToClostestPlayer = curDistance;
			}
		}
	}

	void FindClosestBall()
	{
		foreach (GameObject go in players)
		{
			Vector3 dist = go.transform.position - myPos;
			float curDistance = dist.sqrMagnitude;
			if (curDistance < distToClostestBall)
			{
				closestPlayer = go;
				distToClostestBall = curDistance;
			}
		}
	}

	void Movement()
	{

	}
}
