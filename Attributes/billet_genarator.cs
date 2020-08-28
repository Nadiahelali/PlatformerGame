using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billet_genarator : MonoBehaviour {
	public float timer, counter;
	public GameObject bullet ;
	public Transform bulletcreatepoint;
	public AudioSource fire_sound;
	// Use this for initialization
	void Start () 
	{	fire_sound.mute = true;
		if (bullet == null) {
			bullet = GameObject.FindGameObjectWithTag ("bullet");
		}
		timer = Random.Range (2, 4);
	}
	
	// Update is called once per frame
	void Update ()
	{ fire_sound.mute = false;
		if (GameManager.Instance.enemygunactive == true && GameManager.Instance.gameover == false) {

			counter += Time.deltaTime;
			if (timer <= counter)
			{
				fire_sound.Play ();
				Instantiate (bullet, bulletcreatepoint.position, bulletcreatepoint.rotation);
				timer = Random.Range (3, 9);
				counter = 0;



			}	

			if (GameManager.Instance.BombTrigger == true) {
				Destroy (gameObject);
			}
		}
	}


}
