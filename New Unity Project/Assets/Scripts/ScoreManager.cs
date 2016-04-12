using UnityEngine;


public class ScoreManager : MonoBehaviour {


	[HideInInspector]
	public int score;

	GameObject[] scoreKeepers;


	// Use this for initialization
	void Start ()
	{
		scoreKeepers = GameObject.FindGameObjectsWithTag("ScoreKeeper");
	}
	
	// Update is called once per frame
	void Update ()
	{
		

	}

	
	
}
