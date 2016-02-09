using UnityEngine;
using System.Collections;

public class DefenceTower : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	[SerializeField] GameObject projectilePrefab;
	[SerializeField] Transform projectileSpawnerTransform;
	public GameObject defenceTower;
	public GameObject enemyTarget;

	private float towerRange;

	public float TowerRange{

		get{ return towerRange;}

		set { 	
			
			towerRange = value;

			// set the radius of the tower circle collider to set its range
			GetComponent<CircleCollider2D> ().radius = towerRange;
		}

	}
	public float projectileSpeed;	// speed projectile travels at (bigger number = faster)
	public float fireRate;			// seconds to wait before next shot (smaller number = faster)

	bool isScanningForEnemies = true;
	bool isShooting = false;
	bool hasEnemyLock = false;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake () {

		// Set variable values
	//	towerRange = 2.5f;
	//	projectileSpeed = 5f;
	//	fireRate = 1.2f;
		isScanningForEnemies = true;

		// get reference to gameObject
		defenceTower = gameObject;

		// set the radius of the tower circle collider to set its range
		//GetComponent<CircleCollider2D> ().radius = towerRange;
	
	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start(){

		// start coroutine to scan for enemies
		StartCoroutine("ScanningForEnemies");

	} // Start()
		

	/*=========================== Update() ===================================================*/

	void Update () {

		// check if target is null (Enemy is probably dead)
		if (enemyTarget == null) {

			// drop target lock
			hasEnemyLock = false;

			// stop shooting
			isShooting = false;

		} // if
	
	} // Update()


	/*=========================== ScanningForEnemies() ===================================================*/

	// Coroutine to so control the fireRate of the tower
	IEnumerator ScanningForEnemies(){

		// run while the tower is scanning for enemies
		while (isScanningForEnemies) {
			
			// check if meant to be shooting
			if (isShooting) { // if yes

				// spawn projectile
				SpawnProjectile ();

			} // if

			// wait to simulate a fireRate
			yield return new WaitForSeconds (fireRate);

		} // while

	} // ScanningForEnemies()


	/*=========================== OnTriggerStay2D() ===================================================*/

	// runs when object is colliding
	void OnTriggerStay2D(Collider2D other){

		// if there is not enemyLock
		if (!hasEnemyLock) {
			
			// save transform of object in collider radius
			enemyTarget = other.gameObject;

			// start Shooting
			isShooting = true;

			// now has enemyLock
			hasEnemyLock = true;

			//Debug.Log ("Has Enemy Lock");

		} // if

	} // OnTriggerStay2D()


	/*=========================== OnTriggerExit2D() ===================================================*/

	// runs when an object stops colliding
	void OnTriggerExit2D(Collider2D other){

		// check if the object leaving is the target
		if (enemyTarget == other.gameObject) {

			// drop target lock
			hasEnemyLock = false;

			// stop shooting
			isShooting = false;

			// clear target
			enemyTarget = null;

			//Debug.Log ("Enemy Lock Dropped");

		} // if

		// check if projectile is leaving the tower range
		if (other.tag == "Projectile") {

			// destroy it if it's leaving range
			Destroy(other.gameObject);

		} // if
	
	} // OnTriggerExit2D()
		

	/*=========================== SpawnProjectile() ===================================================*/

	// Spawns a projectile and gives it a target
	void SpawnProjectile(){

		// Instantiate projectile at spawner
		GameObject projectile = (GameObject)Instantiate (projectilePrefab, projectileSpawnerTransform.position, Quaternion.identity);

		// make a child of projectile spawner
		projectile.transform.SetParent(projectileSpawnerTransform, true);

	} // SpawnProjectile()
		

} // class
