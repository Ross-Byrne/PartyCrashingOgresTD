﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// Prefabs
	public GameObject pathLayoutPrefab;
	public GameObject enemyPrefab;


	// UI
	public Text scoreText;
	public Button towerOneButton;
	public Button towerTwoButton;
	public Button towerThreeButton;
	public Button towerFourButton;
	public Button towerFiveButton;
	public Button towerSixButton;
	public Button towerSevenButton;


	// GameObjects
	GameObject pathLayout;


	// Variables
	int gameLevel;
	float enemySpawnerSpeed; // time to wait before next spawn

	public int gameScore;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// Initialise Variables
		gameLevel = 1;
		enemySpawnerSpeed = 0.8f;
		gameScore = 0;

		// Setup the games UI
		SetUpUI();

		// instantiate the pathLayout
		pathLayout = (GameObject)Instantiate (pathLayoutPrefab);

	} // Awake()


	/*=========================== Update() ===================================================*/

	void Start(){

		// spawn an enemy every 10 secs
		InvokeRepeating ("SpawnEnemy", 1f, enemySpawnerSpeed);

	} // Start()


	/*=========================== Update() ===================================================*/

	void Update () {

		// Update the UI

		// check if the score has changed
		if (gameScore != int.Parse(scoreText.text.Substring (7))) { // subString(7) to get rid of "Score: "

			// update the score
			scoreText.text = "Score: " + gameScore.ToString ();

		} // if
	
	} // Update()


	/*=========================== SpawnEnemy() ===================================================*/

	// spawns enemies at the starting point 
	private void SpawnEnemy(){

		// instantiate an enemy
		GameObject enemy = (GameObject)Instantiate (enemyPrefab);

		// position the enemy on the paths starting tile
		enemy.transform.position = pathLayout.GetComponent<Path> ().PathStart.transform.position;

	} // SpawnEnemy()


	/*=========================== SetUpUI() ===================================================*/

	// sets up the games UI
	private void SetUpUI(){

		// add onClick listeners to the spawnTower buttons
		towerOneButton.onClick.AddListener (gameObject.GetComponent<DefenceTowerSpawner>().SpawnTowerLvlOneButton);
		/*towerTwoButton.onClick.AddListener ();
		towerThreeButton.onClick.AddListener ();
		towerFourButton.onClick.AddListener ();
		towerFiveButton.onClick.AddListener ();
		towerSixButton.onClick.AddListener ();
		towerSevenButton.onClick.AddListener ();*/

	} // SetUpUI()


} // class
