using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour
{
	public GameObject ballPrefab;
	private GameObject ball;

	public GameObject spawnPos;
	public Vector3 throwDir = new Vector3(0, 0, -1);
	public float throwSpeed = 10;

	public float spawnTime = 1;
	private float spawnCounter = 0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		spawnCounter += Time.deltaTime;

		if (spawnCounter > spawnTime)
		{
			ball = Instantiate(ballPrefab, spawnPos.transform.position, Quaternion.identity) as GameObject;
			ball.GetComponent<Rigidbody>().AddForce(throwDir * throwSpeed, ForceMode.Impulse);
			spawnCounter = 0;
		}
	}
}
