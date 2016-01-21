using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/*=========================== Member Variables ===========================*/

	// Prefabs
	public GameObject pathLayoutPrefab;
	public GameObject enemyPrefab;

	// GameObjects
	GameObject pathLayout;


	/*=========================== Methods ===========================*/

	/*=========================== Awake() ===========================*/

	void Awake(){

		// instantiate the pathLayout
		pathLayout = (GameObject)Instantiate (pathLayoutPrefab);

	} // Awake()


	/*=========================== Update() ===========================*/

	void Start(){

		// spawn an enemy every 10 secs
		InvokeRepeating ("SpawnEnemy", 1f, 3f);

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
