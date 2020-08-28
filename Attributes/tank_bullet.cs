using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_bullet : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime);

		if (transform.position.x < 16)
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
