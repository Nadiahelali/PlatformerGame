using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	
	public GameObject target;
	// Use this for initialization
	void Start () {
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag ("Player");
		}
	}
	
	// Update is called once per frame
	void Update () {
			transform.position = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);
	}
}
