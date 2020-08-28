using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_trigger : MonoBehaviour {
	public GameObject blast;
	public Transform BlastPoint;


	// Use this for initialization
	void OnTriggerEnter2D( Collider2D col)
	{
		if (GameManager.Instance.birdkey == true) {
        
			Instantiate (blast, BlastPoint.position, BlastPoint.rotation);
			GameManager.Instance.BombTrigger = true;
			GameManager.Instance.health += 2;
		}

	}
}
