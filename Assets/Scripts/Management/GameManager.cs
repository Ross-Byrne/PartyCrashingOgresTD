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

		// instantiate an enemy
		GameObject enemy = (GameObject)Instantiate (enemyPrefab);

		// position the enemy on the paths starting tile
		enemy.transform.position = pathLayout.GetComponent<Path> ().PathStart.transform.position;

	} // Awake()


	/*=========================== Update() ===========================*/

	void Update () {
	
	} // Update()


} // class
