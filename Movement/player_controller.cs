﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player_controller : MonoBehaviour {
	public float speed, horizontal, vertical,  jump;
	public float jumpPower;
	public bool isGrounded;
	public Animator anim;
	public Rigidbody2D rb;
	public Text WinText;
	public Text scoreText;
	public int score;

	//public bool birdkey;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		score = 0;
		//birdkey = false;
	}

	 
	// Update is called once per frame
	void Update () {


		horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * speed ;



		animation ();
		moveing ();
		instruction ();
		scoreText.text = "Score :" + score;
	}


	public void animation()
	{
		if (horizontal > 0) {
			anim.Play ("run", -1);
		} 

		else if (horizontal < 0) {
			anim.Play ("run", -1);
		} 
		else
		{
			anim.Play("idle",-1);
		}
	}

	public void moveing()
	{

		if (Input.GetKeyDown (KeyCode.Space)) {


			if (isGrounded == true) {
				anim.Play ("jump", -1);
				vertical = jump * Time.deltaTime; 

			} else if (isGrounded == false) {
				vertical = 0;

			}
		} else 
		{
			vertical = 0;
		}


		if (horizontal > 0) 
		{
			horizontal = horizontal;
			transform.rotation = Quaternion.AngleAxis (0, Vector3.up);
		}
		else if (horizontal < 0) 
		{
			horizontal = -horizontal;
			transform.rotation = Quaternion.AngleAxis (180, Vector3.up);
		}
			
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
		{
			rb.velocity=Vector3.up*jumpPower;
		}
		transform.Translate (horizontal, vertical, 0);


	}



	public void instruction()
	{
		if (transform.position.x > -9 && transform.position.x <= 15) {
			GameManager.Instance.enemygunactive = true;
		} else 
		{
			GameManager.Instance.enemygunactive = false;
		}

		if (transform.position.x > 18 && transform.position.x <= 48) {
			GameManager.Instance.tankgunactive = true;
		} else 
		{
			GameManager.Instance.tankgunactive = false;
		}
	}
	void OnCollisionEnter2D(Collision2D enter)
	{
		isGrounded = true;

	}

	void OnCollisionExit2D(Collision2D exit)
	{
		isGrounded = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "gunbullet")
		{
			GameManager.Instance.health--;
		}

		if (col.gameObject.tag == "tankbullet")
		{
			GameManager.Instance.health -= 2;
		}

		if (col.gameObject.tag == "enemy")
		{
			GameManager.Instance.health -= 3;
		}
		if (col.gameObject.tag == "key")
		{
			GameManager.Instance.birdkey = true;
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "key2")
		{
			GameManager.Instance.bird2key = true;
			Destroy (col.gameObject);

		}
		if (col.gameObject.tag == "Finish")
		{
			WinText.text="Game Over";
		}
		if (col.gameObject.tag == "coin")
		{
			GameManager.Instance.health +=1;
			Destroy (col.gameObject);
			score++;
		}
		if (col.gameObject.tag == "cherry")
		{
			Destroy (col.gameObject);
			score++;
		}
	}
}
