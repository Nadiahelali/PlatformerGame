using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour {
	public GameObject tankbullet,blast;
	public Transform bullet_point;
	public float timer,counter;

	public AudioSource fire_sound;
	void Start()
	{fire_sound.mute = true;
		timer = Random.Range (2, 4);
	}
	// Update is called once per frame
	void Update () {
		fire_sound.mute = false;
		if (GameManager.Instance.tankgunactive == true && GameManager.Instance.gameover == false) 
		{

			counter += Time.deltaTime;

			if (timer <= counter) {
				fire_sound.Play ();
				Instantiate (blast, bullet_point.position, bullet_point.rotation);
				Instantiate (tankbullet, bullet_point.position, bullet_point.rotation);
				timer = Random.Range (3, 8);
				counter = 0;
			}


			if (GameManager.Instance.TankTrigger == true) {
				Destroy (gameObject);
			}
		}
	}
}
