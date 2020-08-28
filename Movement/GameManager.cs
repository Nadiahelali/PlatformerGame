using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			return instance;
		}
	}
	public bool BombTrigger,  TankTrigger,hit, enemygunactive, tankgunactive, gameover;
	public GameObject EnemySwitch, TimerAndHealthpanel , GameOverPanel, player;
	public int health;

	private float timer, clock;
	public int counter;


	public Slider health_slider;
	public Text timertext;
	public bool birdkey;
	public bool bird2key;



	// Use this for initialization
	void Start () {
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag ("Player");
		}

		instance = this;
		TimerAndHealthpanel.SetActive(true);
		GameOverPanel.SetActive (false);
		health_slider.maxValue = health  ;
		BombTrigger = false;
		TankTrigger = false;
		hit = false;
		enemygunactive = false;
		tankgunactive = false;
		gameover = false;
		timer = 60;
		birdkey = false;
		bird2key = false;

	}
	
	// Update is called once per frame
	void Update () 
	{

		clock += Time.deltaTime;

		counter = Mathf.RoundToInt (clock);
		timertext.text = "TIME :" + counter +" OF " + timer;
		if (timer <= counter) 
		{
			Debug.Log ("GameOver");
		}

		health_slider.value = health;

		if (gameover == true) 
		{

			TimerAndHealthpanel.SetActive(false);
			GameOverPanel.SetActive (true);




			if(health <= 0)
			{	
				gameover = true;
				Destroy (player);
			}
		}
	}
}
