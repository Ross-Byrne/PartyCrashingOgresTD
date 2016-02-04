﻿using UnityEngine;
using System.Collections;

// Manages the spawning of defence towers
// Sets up the towers to have the correct properties for their levels

public class DefenceTowerSpawner : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// Prefabs
	public GameObject defenceTowerPrefab;


	// GameObjects
	private GameObject currentSpawnedTower = null;


	// Variables
	private bool towerIsPlaced = false;
	private bool towerIsSpawned = false;

	[SerializeField]private float lvl1FireRate = 1.2f;
	[SerializeField]private float lvl1TowerRange = 2.5f;
	[SerializeField]private float lvl1ProjectileSpeed = 5f;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// initialise Variables
		/*lvl1FireRate = 1.2f;
		lvl1TowerRange = 2.5f;
		lvl1projectileSpeed = 5f;*/

	} // Awake()


	/*=========================== Update() ===================================================*/

	void Update(){

		// if the tower is spawned but not places
		if (towerIsSpawned && !towerIsPlaced) {

			// lock tower position to mouse until places

		} // if

	} // Update()


	/*=========================== SpawnDefenceTower() ===================================================*/

	// Spawns a tower based on level given
	void SpawnDefenceTower(int level){

		Debug.Log ("Spawn Tower LVL: " + level);

		// spawn the tower
		currentSpawnedTower = (GameObject)Instantiate (defenceTowerPrefab);

		// setup tower
		switch (level) {
		case 1:

			// set the towers fire rate
			currentSpawnedTower.GetComponent<DefenceTower> ().fireRate = lvl1FireRate;

			// set the towers range
			currentSpawnedTower.GetComponent<DefenceTower> ().towerRange = lvl1TowerRange;

			// set the towers projectile speed
			currentSpawnedTower.GetComponent<DefenceTower> ().projectileSpeed = lvl1ProjectileSpeed;

			break;
		default:

			Debug.Log ("Error, Not a tower!");
			break;

		} // switch

		// flag as spawned
		towerIsSpawned = true;

	} // SpawnDefenceTower()


	/*=========================== SpawnTowerLvlOneButton() ===================================================*/

	// this is a button OnClick method
	// spawns a level one tower
	public void SpawnTowerLvlOneButton(){

		// spawn a level one tower
		SpawnDefenceTower (1);

	} // SpawnTowerLvlOneButton()


} // class
