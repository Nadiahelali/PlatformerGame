using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blast_clinner : MonoBehaviour {

	// Use this for initialization
	void OnEnable()
	{
		Destroy (gameObject, 0.5f);
	}
}
