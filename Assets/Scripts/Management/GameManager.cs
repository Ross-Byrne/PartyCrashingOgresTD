using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/*=========================== Member Variables ===========================*/

	// Prefabs
	public GameObject pathLayoutPrefab;
	public GameObject enemyPrefab;

	// GameObjects
	GameObject pathLayout;

	float enemySpawnerSpeed = 0.8f; // time to wait before next spawn

	/*=========================== Methods ===========================*/

	/*=========================== Awake() ===========================*/

	void Awake(){

		// instantiate the pathLayout
		pathLayout = (GameObject)Instantiate (pathLayoutPrefab);

	} // Awake()


	/*=========================== Update() ===========================*/

	void Start(){

		// spawn an enemy every 10 secs
		InvokeRepeating ("SpawnEnemy", 1f, enemySpawnerSpeed);

	} // Start()


	/*=========================== Update() ===========================*/

	void Update () {


	
	} // Update()


	/*=========================== SpawnEnemy() ===========================*/

	// spawns enemies at the starting point 
	private void SpawnEnemy(){

		// instantiate an enemy
		GameObject enemy = (GameObject)Instantiate (enemyPrefab);

		// position the enemy on the paths starting tile
		enemy.transform.position = pathLayout.GetComponent<Path> ().PathStart.transform.position;

	} // SpawnEnemy()


} // class
