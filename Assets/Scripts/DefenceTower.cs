using UnityEngine;
using System.Collections;

public class DefenceTower : MonoBehaviour {


	[SerializeField] GameObject projectilePrefab;
	[SerializeField] Transform projectileSpawnerTransform;
	public GameObject defenceTower;
	public GameObject enemyTarget;

	float towerRange = 2.5f;
	float projectileSpeed = 1f;
	float fireRate = 3f;
	bool startShooting = false;
	bool stopShooting = false;
	[SerializeField]bool hasEnemyLock = false;


	void Awake () {

		// get reference to gameObject
		defenceTower = gameObject;

		// set the radius of the tower circle collider to set its range
		GetComponent<CircleCollider2D> ().radius = towerRange;
	
	} // Awake()
		

	void Update () {

		if (startShooting) {

			// Shoot the enemy
			InvokeRepeating("SpawnProjectile", 0f, fireRate);

			startShooting = false;

		} else if (stopShooting){

			CancelInvoke ();

			stopShooting = false;

		} // if

		if (enemyTarget == null) {

			hasEnemyLock = false;
			stopShooting = true;

		} // if
	
	} // Update()


	void OnTriggerEnter2D(Collider2D other){

		if (!hasEnemyLock) {
			
			// save transform of object in collider radius
			enemyTarget = other.gameObject;

			// start Shooting
			startShooting = true;

			// now has enemyLock
			hasEnemyLock = true;

			//Debug.Log ("Has Enemy Lock");

		} // if

	} // OnTriggerEnter2D()


	void OnTriggerExit2D(Collider2D other){

		if (enemyTarget == other.gameObject) {

			hasEnemyLock = false;

			stopShooting = true;

			enemyTarget = null;

			//Debug.Log ("Enemy Lock Dropped");

		} // if

		// check if projectile is leaving the tower range
		if (other.tag == "Projectile") {

			// destroy it if it's leaving range
			Destroy(other.gameObject);

		} // if
	
	} // OnTriggerExit2D()


	// Spawns a projectile and gives it a target
	void SpawnProjectile(){

		// Instantiate projectile at spawner
		GameObject projectile = (GameObject)Instantiate (projectilePrefab, projectileSpawnerTransform.position, Quaternion.identity);

		// make a child of projectile spawner
		projectile.transform.SetParent(projectileSpawnerTransform, true);

	} // SpawnProjectile()
		
} // class
