using UnityEngine;
using System.Collections;

public class BallParticle : MonoBehaviour
{
	public ParticleSystem particles;
	
	void OnDestroy()
	{
		var particle = Instantiate(particles, GetComponentInParent<Transform>().position, Quaternion.identity);
	}
}
