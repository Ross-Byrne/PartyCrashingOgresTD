using UnityEngine;
using System.Collections;

// Manages the spawning of defence towers
// Sets up the towers to have the correct properties for their levels

public class DefenceTowerSpawner : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// Prefabs
	public GameObject defenceTowerLvl1Prefab;
	public GameObject defenceTowerLvl2Prefab;


	// GameObjects
	private GameObject currentSpawnedTower = null;


	// Variables
	private bool towerIsPlaced = false;
	public bool towerIsSpawned = false;
	private float zValue;

	[SerializeField]private float lvl1FireRate;
	[SerializeField]private float lvl1TowerRange;
	[SerializeField]private float lvl1ProjectileSpeed;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// initialise Variables
		lvl1FireRate = 0.8f;
		lvl1TowerRange = 2.5f;
		lvl1ProjectileSpeed = 7f;

		zValue = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);

	} // Awake()


	/*=========================== Update() ===================================================*/

	void Update(){

		// if the tower is spawned but not places
		if (towerIsSpawned && !towerIsPlaced) {

			Vector3 targetPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zValue);

			targetPos = Camera.main.ScreenToWorldPoint (targetPos);

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

	// Spawns a tower based on level given
	public void SpawnDefenceTower(int level){

		Debug.Log ("Spawn Tower LVL: " + level);

		// get the coord for the mouse
		Vector3 targetPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zValue);

		// translate them to game world coords
		targetPos = Camera.main.ScreenToWorldPoint (targetPos);

		// setup tower
		switch (level) {
		case 1:

			// spawn the tower where the mouse is
			currentSpawnedTower = (GameObject)Instantiate (defenceTowerLvl1Prefab, targetPos, Quaternion.identity);

			// set the towers fire rate
			currentSpawnedTower.GetComponent<DefenceTower> ().fireRate = lvl1FireRate;

			// set the towers range
			currentSpawnedTower.GetComponent<DefenceTower> ().TowerRange = lvl1TowerRange;

			// set the towers projectile speed
			currentSpawnedTower.GetComponent<DefenceTower> ().projectileSpeed = lvl1ProjectileSpeed;

			break;
		case 2:

			// spawn the tower where the mouse is
			currentSpawnedTower = (GameObject)Instantiate (defenceTowerLvl2Prefab, targetPos, Quaternion.identity);

			// set the towers fire rate
			currentSpawnedTower.GetComponent<DefenceTower> ().fireRate = lvl1FireRate;

			// set the towers range
			currentSpawnedTower.GetComponent<DefenceTower> ().TowerRange = lvl1TowerRange;

			// set the towers projectile speed
			currentSpawnedTower.GetComponent<DefenceTower> ().projectileSpeed = lvl1ProjectileSpeed;

			break;
		default:

			Debug.Log ("Error, Not a tower!");
			break;

		} // switch

		// flag as spawned
		towerIsSpawned = true;
		towerIsPlaced = false;

		// disable tower spawning ui
		gameObject.GetComponent<GameManager>().EnableDisableTowerUI(false);

	} // SpawnDefenceTower()


} // class
