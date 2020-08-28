using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_control : MonoBehaviour {


	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.right * Time.deltaTime);

		if (transform.position.x < -12)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Destroy (gameObject);
		}
	}
}
