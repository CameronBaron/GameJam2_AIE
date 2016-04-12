using UnityEngine;
using System.Collections;

public class GoalieDefenceAI : MonoBehaviour
{
    public Transform[] Waypoints;        // The amount of Waypoint you want
    public float patrolSpeed = 3;        // The walking speed between Waypoints
    bool loopWaypoints = true;           // Do you want to keep repeating the Waypoints

    private int currentWaypoint = 0;
    private CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (currentWaypoint < Waypoints.Length)
        {
            Patrol();
        }
        else
        {
            if (loopWaypoints)
            {
                currentWaypoint = 0;
            }
        }
    }

    void Patrol()
    {
        Vector3 target = Waypoints[currentWaypoint].position;
        Vector3 moveDirection = target - transform.position;

        if (moveDirection.magnitude < 2.0)
        {
            currentWaypoint++;
        }

        else
        {
            character.Move(moveDirection.normalized * patrolSpeed * Time.deltaTime);
        }
    }
}