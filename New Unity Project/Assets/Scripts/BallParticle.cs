using UnityEngine;
using System.Collections;

public class BallParticle : MonoBehaviour
{
	public ParticleSystem particles;
	
	void OnDestroy()
	{
		if (particles != null)
		{
			var particle = Instantiate(particles, GetComponentInParent<Transform>().position, Quaternion.identity);
		}
	}
}
