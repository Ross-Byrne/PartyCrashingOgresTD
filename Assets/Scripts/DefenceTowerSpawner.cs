using UnityEngine;
using System.Collections;

// Manages the spawning of defence towers
// Sets up the towers to have the correct properties for their levels

public class DefenceTowerSpawner : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// GameObjects
	private GameObject currentSpawnedTower = null;


	// Variables
	private bool towerIsPlaced = false;
	public bool towerIsSpawned = false;
	private float zValue;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// initialise Variables
	
		zValue = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);

	} // Awake()


	/*=========================== Update() ===================================================*/

	void Update(){

		// if the tower is spawned but not places
		if (towerIsSpawned && !towerIsPlaced) {

			// target pos is the position of mouse
			Vector3 targetPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zValue);

			// get position of mouse in game coords
			targetPos = Camera.main.ScreenToWorldPoint (targetPos);

			// if tower is not on mouse, lock the tower to the position of the mouse
			if (Vector3.Distance(currentSpawnedTower.transform.position, targetPos) > 0) {
				
				// lock tower position to mouse until places
				currentSpawnedTower.transform.position = Vector3.Lerp (currentSpawnedTower.transform.position, targetPos, 15 * Time.deltaTime);

			} // if

		} // if

		// if the mouse is clicked
		if (Input.GetMouseButtonDown (0)) {

			// if tower is spawned but not placed
			if (towerIsSpawned && !towerIsPlaced) {

				// flag tower as placed
				towerIsPlaced = true;

				// set tower is spawned to false
				towerIsSpawned = false;

				// clear placed tower's reference
				currentSpawnedTower = null;

				// enable tower spawning ui
				gameObject.GetComponent<GameManager>().EnableDisableTowerUI(true);

			} // if
		} // if

	} // Update()


	/*=========================== SpawnDefenceTower() ===================================================*/

	// spawns defence tower based on level given
	public void SpawnDefenceTower(int level){

		// to safety check that that prefab exists
		if (level < 6 && level > 0) {

			// get the coord for the mouse
			Vector3 targetPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zValue);

			// translate them to game world coords
			targetPos = Camera.main.ScreenToWorldPoint (targetPos);

			// spawn the tower where the mouse is using Resources folder to load correct tower
			currentSpawnedTower = (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/DefenceTowerLvl" + level), targetPos, Quaternion.identity);

			// set the towers fire rate
			currentSpawnedTower.GetComponent<DefenceTower> ().fireRate = GetComponent<TowerStats> ().GetTowerFireRate (level);

			// set the towers projectile speed
			currentSpawnedTower.GetComponent<DefenceTower> ().projectileSpeed = GetComponent<TowerStats> ().GetTowerProjectileSpeed (level);

			// set towers projectile damage
			currentSpawnedTower.GetComponent<DefenceTower>().projectileDamage = GetComponent<TowerStats> ().GetTowerProjectileDamage (level);

			// flag as spawned
			towerIsSpawned = true;
			towerIsPlaced = false;

			// disable tower spawning ui
			GetComponent<GameManager>().EnableDisableTowerUI(false);

		} else {

			Debug.Log ("Error, That Tower Does Not Exist!");

		} // if

	} // SpawnDefenceTower()
		

} // class
