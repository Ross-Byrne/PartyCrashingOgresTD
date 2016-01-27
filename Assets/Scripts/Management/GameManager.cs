using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// Prefabs
	public GameObject pathLayoutPrefab;
	public GameObject enemyPrefab;

	// UI
	public Text scoreText;

	// GameObjects
	GameObject pathLayout;

	float enemySpawnerSpeed; // time to wait before next spawn

	public int gameScore;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// Initialise Variables
		enemySpawnerSpeed = 0.8f;
		gameScore = 0;

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


} // class
