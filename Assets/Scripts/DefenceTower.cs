using UnityEngine;
using System.Collections;

public class DefenceTower : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	[SerializeField] GameObject projectilePrefab;
	[SerializeField] Transform[] projectileSpawnerTransforms;
	public GameObject defenceTower;
	public GameObject towerRangeSprite;
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
	public int projectileDamage;

	bool isScanningForEnemies = true;
	bool isShooting = false;
	bool hasEnemyLock = false;
	public bool CanShoot { get; set; }

	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake () {

		// Set variable values

		isScanningForEnemies = true;

		// cant shoot once spawned, only once placed
		CanShoot = false;

		// get reference to gameObject
		defenceTower = gameObject;
	
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
			if (isShooting == true && CanShoot == true) { // if yes

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

		// spawn a projectile for each spawner
		for (int i = 0; i < projectileSpawnerTransforms.Length; i++) {
			
			// Instantiate projectile at spawner
			GameObject projectile = (GameObject)Instantiate (projectilePrefab, projectileSpawnerTransforms [i].position, Quaternion.identity);

			// make a child of projectile spawner
			projectile.transform.SetParent (projectileSpawnerTransforms [i], true);

		} // for

	} // SpawnProjectile()
		

	/*=========================== DisableTowerRange() ===================================================*/

	public void DisableTowerRange(){

		// disable the tower range sprite
		towerRangeSprite.SetActive(false);

	} // DisableTowerRange()
		

} // class
