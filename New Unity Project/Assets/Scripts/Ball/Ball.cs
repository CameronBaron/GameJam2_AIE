using UnityEngine;

[RequireComponent(typeof (Rigidbody))]

public class Ball : MonoBehaviour
{
	Rigidbody rb;
	PhysicMaterial pmat;

	public float lifeTime = 20;
	private float lifetTimeDefault = 20;
	private float lifeCounter = 0;

	private float bounces = 0;

	//Powerup Vars
	private int maxBounces = 10000;             // For Rikochet ball
	private int maxBouncesDefault = 1;
	private float scale = 1;					// For Giant Ball
	private GameObject target = null;               // For Homing ball

	// Physics Mat
	private float bounciness = 1;	

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		pmat = GetComponent<PhysicMaterial>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rb.velocity != Vector3.zero)
			lifeCounter += Time.deltaTime;

		if (lifeCounter > lifeTime || bounces > maxBounces)
		{
			Destroy(gameObject);
		}
	}

	// On Collision Enter
	void OnCollisionEnter(Collision col)
	{
		foreach (ContactPoint contact in col.contacts)
		{
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
		}

		if (col.gameObject.tag == "Player")
		{
			// remove health
		}
		else
		{
			bounces++;
		}

		if (col.relativeVelocity.magnitude > 2)
		{
			//play audio
		}
	}
}
