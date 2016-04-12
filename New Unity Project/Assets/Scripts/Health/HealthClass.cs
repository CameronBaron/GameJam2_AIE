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

	public string team;

	// Use this for initialization
	void Start ()
    {
        bc = GetComponent<BoxCollider>();
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

        while (isInvulnerable)
        {
            invulnerabilityTimer += Time.deltaTime;
            bc.enabled = false;

            if (invulnerabilityTimer >= invulnerabilityTime)
            {
                isInvulnerable = false;
                bc.enabled = true;
                invulnerabilityTimer = 0;
            }
        }
    }
}
