using UnityEngine;
using InControl;
using System.Collections.Generic;

public class ControllerSetup : MonoBehaviour
{
	public GameObject[] playerPrefabs = new GameObject[4];

	public Queue<Vector3> spawnPos = new Queue<Vector3>();

	private List<GameObject> players = new List<GameObject>();
	private const int maxPlayers = 4;
	private int currPlayer = 0;
	// Use this for initialization
	void Start ()
	{
		spawnPos.Enqueue(new Vector3(2, 1, 0));
		spawnPos.Enqueue(new Vector3(2, 1, 2));
		spawnPos.Enqueue(new Vector3(0, 1, 2));
		spawnPos.Enqueue(new Vector3(0, 1, 0));
	}
	
	// Update is called once per frame
	void Update ()
	{
		var inputDevice = InputManager.ActiveDevice;

		if (JoinButtonWasPressedOnDevice(inputDevice))
		{
			if (!FindPlayerUsingDevice(inputDevice))
			{
				CreatePlayer(inputDevice);
			}
		}
	}

	bool JoinButtonWasPressedOnDevice(InputDevice inputDevice)
	{
		return inputDevice.Command.WasPressed;
	}

	bool FindPlayerUsingDevice(InputDevice inputDevice)
	{
		int pCount = players.Count;
		for (int i = 0; i < pCount; i++)
		{
			var p = players[i];
			if (p.GetComponent<PlayerMovementScript>().input == inputDevice)
			{
				return true;
			}
		}
		return false;
	}

	void CreatePlayer(InputDevice input)
	{
		if (players.Count < maxPlayers)
		{
			var p = Instantiate(playerPrefabs[currPlayer], spawnPos.Dequeue(), Quaternion.identity) as GameObject; // Need spawn position
			p.GetComponent<PlayerMovementScript>().input = input;
			players.Add(p);

			if (players.Count % 2 == 0)
			{
				p.GetComponent<HealthClass>().team = "Red";
			}
			else
			{
				p.GetComponent<HealthClass>().team = "Blue";
			}
			currPlayer++;
		}
	}
}
