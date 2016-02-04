using UnityEngine;
using System.Collections;

// Manages the spawning of defence towers
// Sets up the towers to have the correct properties for their levels

public class DefenceTowerSpawner : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// Prefabs
	public GameObject defenceTowerPrefab;


	// Variables
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


	/*=========================== SpawnDefenceTower() ===================================================*/

	// Spawns a tower based on level given
	void SpawnDefenceTower(int level){

		Debug.Log ("Spawn Tower LVL: " + level);

	} // SpawnDefenceTower()


	/*=========================== SpawnTowerLvlOneButton() ===================================================*/

	// this is a button OnClick method
	// spawns a level one tower
	public void SpawnTowerLvlOneButton(){

		// spawn a level one tower
		SpawnDefenceTower (1);

	} // SpawnTowerLvlOneButton()


} // class
