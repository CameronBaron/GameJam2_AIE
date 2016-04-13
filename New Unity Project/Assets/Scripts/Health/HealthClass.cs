using UnityEngine;
using System.Collections;

public class HealthClass : MonoBehaviour
{
    /*
        things to add to this:
        
        Particle effects on respawn
    */
    public float playerHealth = 100;
	
    bool isInvulnerable = false;
    bool isDying = false;

    float invulnerableCounter;
    public float invulnerabilityTime;

    private BoxCollider bc;
    public GameObject respawnPoint;

	public ParticleSystem deathParticles;

	public string team;

	Color originalColor;

	// Use this for initialization
	void Start ()
    {
        bc = GetComponent<BoxCollider>();
		originalColor = GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerHealth <= 0)
        {
            isDying = true;
            PlayerDeath();
        }
	}

    void PlayerDeath()
    {
        float respawnTimer = 0;

        while (isDying)
        {
            respawnTimer += Time.deltaTime;
            
            if (respawnTimer <= 1.0f)
            {
                isDying = false;
                isInvulnerable = true;
                PlayerRespawn();
            }
        }
    }

    void PlayerRespawn()
    {
        float invulnerabilityTimer = 0;

        //transform.position = respawnPoint.transform.position;
        playerHealth = 100;

		while (isInvulnerable)
		{
			Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Cos(Time.deltaTime));
			invulnerabilityTimer += Time.deltaTime;
            bc.enabled = false;

			GetComponent<Renderer>().material.color = newColor;

            if (invulnerabilityTimer >= invulnerabilityTime)
            {
                isInvulnerable = false;
                bc.enabled = true;
                invulnerabilityTimer = 0;
				GetComponent<Renderer>().material.color = originalColor;
			}
        }
    }

	void Destroy()
	{
		if (deathParticles != null)
		{
			ParticleSystem ps = Instantiate(deathParticles, transform.position, Quaternion.identity) as ParticleSystem;
		}
	}
}
