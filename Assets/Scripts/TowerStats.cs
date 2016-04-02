using UnityEngine;
using System.Collections;

// Script to keep track of Defence tower stats

public class TowerStats : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// seconds to wait before next shot (smaller number = faster)
	public float TowerLvl1FireRate { get; set; }
	public float TowerLvl2FireRate { get; set; }
	public float TowerLvl3FireRate { get; set; }
	public float TowerLvl4FireRate { get; set; }
	public float TowerLvl5FireRate { get; set; }

	// speed projectile travels at (bigger number = faster)
	public float TowerLvl1ProjectileSpeed { get; set; }
	public float TowerLvl2ProjectileSpeed { get; set; }
	public float TowerLvl3ProjectileSpeed { get; set; }
	public float TowerLvl4ProjectileSpeed { get; set; }
	public float TowerLvl5ProjectileSpeed { get; set; }

	// number of health points taken off enemy per shot
	public int TowerLvl1ProjectileDamage { get; set; }
	public int TowerLvl2ProjectileDamage { get; set; }
	public int TowerLvl3ProjectileDamage { get; set; }
	public int TowerLvl4ProjectileDamage { get; set; }
	public int TowerLvl5ProjectileDamage { get; set; }


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// initialise Variables

		TowerLvl1FireRate = 1f;
		TowerLvl2FireRate = 0.6f;
		TowerLvl3FireRate = 1.6f;
		TowerLvl4FireRate = 1.6f;
		TowerLvl5FireRate = 0.8f;

		TowerLvl1ProjectileSpeed = 7f;
		TowerLvl2ProjectileSpeed = 7;
		TowerLvl3ProjectileSpeed = 7f;
		TowerLvl4ProjectileSpeed = 6.4f;
		TowerLvl5ProjectileSpeed = 7f;

		TowerLvl1ProjectileDamage = 1;
		TowerLvl2ProjectileDamage = 1;
		TowerLvl3ProjectileDamage = 1;
		TowerLvl4ProjectileDamage = 2;
		TowerLvl5ProjectileDamage = 3;

	} // Awake()


	/*=========================== GetTowerFireRate() ===================================================*/

	// return the fire rate for a certain level tower
	public float GetTowerFireRate(int level){

		float fireRate = 0;

		switch (level) {
		case 1:

			fireRate = TowerLvl1FireRate;
			break;
		case 2:

			fireRate = TowerLvl2FireRate;
			break;
		case 3:

			fireRate = TowerLvl3FireRate;
			break;
		case 4:

			fireRate = TowerLvl4FireRate;
			break;
		case 5:

			fireRate = TowerLvl5FireRate;
			break;
		} // switch

		// return fireRate
		return fireRate;

	} // GetTowerFireRate()


	/*=========================== GetTowerProjectileSpeed() ===================================================*/

	// return the projectile speed for a certain level tower
	public float GetTowerProjectileSpeed(int level){

		float speed = 0;

		switch (level) {
		case 1:

			speed = TowerLvl1ProjectileSpeed;
			break;
		case 2:

			speed = TowerLvl2ProjectileSpeed;
			break;
		case 3:

			speed = TowerLvl3ProjectileSpeed;
			break;
		case 4:

			speed = TowerLvl4ProjectileSpeed;
			break;
		case 5:

			speed = TowerLvl5ProjectileSpeed;
			break;
		} // switch

		// return speed
		return speed;

	} // GetTowerProjectileSpeed()


	/*=========================== GetTowerProjectileDamage() ===================================================*/

	// return the projectile damage for a certain level tower
	public int GetTowerProjectileDamage(int level){

		int damage = 0;

		switch (level) {
		case 1:

			damage = TowerLvl1ProjectileDamage;
			break;
		case 2:

			damage = TowerLvl2ProjectileDamage;
			break;
		case 3:

			damage = TowerLvl3ProjectileDamage;
			break;
		case 4:

			damage = TowerLvl4ProjectileDamage;
			break;
		case 5:

			damage = TowerLvl5ProjectileDamage;
			break;
		} // switch

		// return damage
		return damage;

	} // GetTowerProjectileDamage()


} // class
