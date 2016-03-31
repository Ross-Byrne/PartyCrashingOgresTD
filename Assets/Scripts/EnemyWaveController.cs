using UnityEngine;
using System.Collections;

// Script to control the enemy waves Spawned during each game level

public class EnemyWaveController : MonoBehaviour {

	// each int is an enemy number
	int[] wave1 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
	int[] wave2 = new int[] { 1, 1, 1, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2 };
	int[] wave3 = new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3, 3, 3, 2, 2, 1, 1, 2, 3, 3, 3, 3, 3, 3 };
	int[] wave4 = new int[] { 1, 2, 3, 3, 3, 4, 4, 4, 3, 3, 3, 3, 3, 2, 2, 3, 3, 4, 4, 4 };
	int[] wave5 = new int[] { 3, 4, 5, 3, 3, 3, 4, 4, 4, 5, 5, 5, 5, 5, 5 };

	// an array of arrays to hold the different waves
	int[][] waves;

	GameManager gameManager;

	public bool waveOver = true;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// an array of arrays to hold the different waves
		waves = new int[][] { wave1, wave2, wave3, wave4, wave5 };

		// get reference to gameManager
		gameManager = GetComponent<GameManager>();

	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start(){

		// start wave (based on game level) -1 because 0 index
		StartCoroutine(StartWave(gameManager.GameLevel -1));

		// wave have started
		waveOver = false;

	} // Start()


	/*=========================== Update() ===================================================*/

	void Update () {
	
		// control when waves start and finish in gameManager?

		if (gameManager.GameHasStarted == true && waveOver == true) {

			// start wave (based on game level)
			//StartCoroutine(StartWave(GetComponent<GameManager>().GameLevel));

			// wave have started
			//waveOver = false;

		} // if

	} // Update()


	/*=========================== StartWave() ===================================================*/

	// starts spawning enemies for wave number passed in
	public IEnumerator StartWave(int waveNum){

		Debug.Log ("Number of Waves: " + waves.Length);
		Debug.Log ("Enemies in wave " + (waveNum + 1) + ": " + waves[waveNum].Length);

		// tell manager how manay enemies are alive
		gameManager.EnemiesAlive = waves[gameManager.GameLevel -1].Length;

		// loop through the wave and spawn the enemy
		for(int i = 0; i < waves[waveNum].Length; i++){
			
			// spawn an enemy for the wave
			GetComponent<EnemySpawner>().SpawnEnemy(waves[waveNum][i]);

			// wait a cetain amount of time before spawning a new enemy
			yield return new WaitForSeconds (GetComponent<EnemySpawner>().EnemySpawnerSpeed);

		} // for
			
	} // StartWave()


} // class
