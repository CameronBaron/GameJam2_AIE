using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	[HideInInspector]
	public int score;

	public GUIText scoreBoard;

	// Use this for initialization
	void Start()
	{
		gameObject.tag = "ScoreKeeper";
		score = 0;
	}

	// Update is called once per frame
	void Update()
	{
		scoreBoard.text = score.ToString();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ball")
		{
			score++;
			Debug.Log("score : " + score);
			Destroy(col.gameObject);
		}
	}
}
