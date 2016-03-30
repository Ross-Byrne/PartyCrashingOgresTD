using UnityEngine;
using System.Collections;

// Script to handle spawning enemies

public class EnemySpawner : MonoBehaviour {

	// Variables

	public float EnemySpawnerSpeed { get; set; } // time to wait before next spawn


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake () {
	
		// initialise variables

		EnemySpawnerSpeed = 1.8f;

	} // Awake()


	/*=========================== SpawnEnemy() ===================================================*/

	// spawns enemies at the starting point of the path
	public void SpawnEnemy(int level){

		// to safety check that that prefab exists
		if (level < 6 && level > 0) {

			// instantiate an enemy
			GameObject enemy = (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/EnemyLvl" + level));

			// position the enemy on the paths starting tile
			enemy.transform.position = GetComponent<GameManager> ().pathLayout.GetComponent<Path> ().PathStart.transform.position;

			// set Enemy's Total Health
			enemy.GetComponent<Enemy> ().TotalHealth = GetComponent<EnemyStats> ().GetEnemyTotalHealth (level);

			// set Enemy's Health
			enemy.GetComponent<Enemy> ().Health = enemy.GetComponent<Enemy> ().TotalHealth;

			// set Enemy's Speed
			enemy.GetComponent<Enemy> ().Speed = GetComponent<EnemyStats> ().GetEnemySpeed (level);

			// Set Enemy's Score
			enemy.GetComponent<Enemy> ().ScoreForKillingMe = GetComponent<EnemyStats> ().GetEnemyScore (level);

		} else {

			Debug.Log ("Error, That Enemy Does Not Exist!");

		} // if

	} // SpawnEnemy()
		

} // class
