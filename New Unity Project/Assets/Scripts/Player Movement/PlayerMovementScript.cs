﻿using UnityEngine;
using InControl;

public class PlayerMovementScript : MonoBehaviour
{
    public InputDevice input { get; set; }

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float dodgePower = 50;
    [SerializeField]
    private float dodgeCooldownTimer = 0;
    [SerializeField]
    private float dodgeResetTime = 0;

    private Rigidbody rb;

    bool isGrounded = true;
    bool canDodge = true;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        dodgeCooldownTimer += Time.deltaTime;
		Vector3 directionOfStick = Vector3.zero;

		if (input != null)
		{
			directionOfStick = new Vector3(input.LeftStick.X, 0, input.LeftStick.Y);
		}

        /* *****************************************************
           Update part done for updating the position of the player 
           ***************************************************** */ 
        if (input.LeftStick.X != 0.0f && input.LeftStickY != 0.0f)
        {
            transform.position += new Vector3(input.LeftStick.X * movementSpeed * Time.deltaTime, 0, input.LeftStick.Y * movementSpeed * Time.deltaTime);
        }

        /* *****************************************************
           Update part done for updating the rotation and looking position of the player 
           ***************************************************** */
        if (input.RightStick.X != 0.0f && input.RightStick.Y != 0.0f)
        {
            Vector3 lookAtPosition = transform.position + new Vector3(input.RightStickX, 0.0f, input.RightStickY);
            Vector3 rotation = transform.rotation.eulerAngles;
            transform.LookAt(lookAtPosition);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotation), transform.rotation, 0.2f);
        }

        /* *****************************************************
           Update part to control the cooling down of the dodge timers & dodge control
           ***************************************************** */
        if (dodgeCooldownTimer >= dodgeResetTime)
        {
            canDodge = true;
            dodgeCooldownTimer = 0;
        }

        if (canDodge)
        {
            if (input.LeftBumper.WasPressed)
            {
                rb.AddForce(directionOfStick * dodgePower, ForceMode.Impulse);
                canDodge = false;
            }
        }        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
