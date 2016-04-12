using UnityEngine;
using System.Collections;

public class HealthClass : MonoBehaviour
{
    /*
        things to add to this:
        
        Particle effects on respawn
    */
    public float playerHealth = 100;

    bool isDead;
    bool isInvulnerable;
    bool isDying;

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
            if (!isDead)
            {
                isDying = true;
                PlayerDeath();
            }
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
                PlayerRespawn();
                isDying = false;
                isInvulnerable = true;
            }
        }
    }

    void PlayerRespawn()
    {
        float invulnerabilityTimer = 0;

        transform.position = respawnPoint.transform.position;
        playerHealth = 100;
		Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Cos(Time.deltaTime));

		while (isInvulnerable)
        {
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

	void OnDestroy()
	{
		if (deathParticles != null)
		{
			ParticleSystem ps = Instantiate(deathParticles, transform.position, Quaternion.identity) as ParticleSystem;
		}
	}
}
