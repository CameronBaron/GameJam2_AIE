using UnityEngine;

[RequireComponent(typeof (Rigidbody))]

public class Ball : MonoBehaviour
{
	Rigidbody rb;
	PhysicMaterial pmat;

	public Vector3 gravity = new Vector3(0, -4, 0);

	public float lifeTime = 20;
	private float lifetTimeDefault = 20;
	private float lifeCounter = 0;
	
	public float damage = 100;

	//Powerup Vars
	private float scale = 1;					// For Giant Ball
	private GameObject target = null;               // For Homing ball

	// Physics Mat
	private float bounciness = 1;	

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		pmat = GetComponent<PhysicMaterial>();
		gameObject.tag = "Ball";
	}
	
	// Update is called once per frame
	void Update ()
	{
		rb.AddForce(gravity, ForceMode.Force);
		if (rb.velocity != Vector3.zero)
			lifeCounter += Time.deltaTime;

		if (lifeCounter > lifeTime)
		{
			Destroy(gameObject);
		}
	}
}
