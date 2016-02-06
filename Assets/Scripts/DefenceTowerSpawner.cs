using UnityEngine;
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
	public bool towerIsSpawned = false;
	private float zValue;

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
	void SpawnDefenceTower(int level){

		Debug.Log ("Spawn Tower LVL: " + level);

		// spawn the tower
		currentSpawnedTower = (GameObject)Instantiate (defenceTowerPrefab, transform.position, Quaternion.identity);

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
		towerIsPlaced = false;

		// disable tower spawning ui
		gameObject.GetComponent<GameManager>().EnableDisableTowerUI(false);

	} // SpawnDefenceTower()


	/*=========================== SpawnTowerLvlOneButton() ===================================================*/

	// this is a button OnClick method
	// spawns a level one tower
	public void SpawnTowerLvlOneButton(){

		// spawn a level one tower
		SpawnDefenceTower (1);

	} // SpawnTowerLvlOneButton()


} // class
