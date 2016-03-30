using UnityEngine;
using System.Collections;

// Script to keep track of enemies stats

public class EnemyStats : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	public int EnemyLvl1TotalHeath { get; set; }
	public int EnemyLvl2TotalHeath { get; set; }
	public int EnemyLvl3TotalHeath { get; set; }
	public int EnemyLvl4TotalHeath { get; set; }
	public int EnemyLvl5TotalHeath { get; set; }

	public float EnemyLvl1Speed { get; set; }
	public float EnemyLvl2Speed { get; set; }
	public float EnemyLvl3Speed { get; set; }		
	public float EnemyLvl4Speed { get; set; }
	public float EnemyLvl5Speed { get; set; }

	public int EnemyLvl1Score { get; set; }
	public int EnemyLvl2Score { get; set; }
	public int EnemyLvl3Score { get; set; }
	public int EnemyLvl4Score { get; set; }
	public int EnemyLvl5Score { get; set; }


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// initialise Variables

		EnemyLvl1TotalHeath = 1;
		EnemyLvl2TotalHeath = 2;
		EnemyLvl3TotalHeath = 4;
		EnemyLvl4TotalHeath = 6;
		EnemyLvl5TotalHeath = 10;

		EnemyLvl1Speed = 0.8f;
		EnemyLvl2Speed = 1f;
		EnemyLvl3Speed = 1.4f;
		EnemyLvl4Speed = 0.68f;
		EnemyLvl5Speed = 0.6f;

		EnemyLvl1Score = 10;
		EnemyLvl2Score = 20;
		EnemyLvl3Score = 30;
		EnemyLvl4Score = 40;
		EnemyLvl5Score = 50;

	} // Awake()


	/*=========================== GetEnemyTotalHealth() ===================================================*/

	// return the total health for a certain level enemy
	public int GetEnemyTotalHealth(int level){

		int health = 0;

		switch (level) {
		case 1:

			health = EnemyLvl1TotalHeath;
			break;
		case 2:

			health = EnemyLvl2TotalHeath;
			break;
		case 3:

			health = EnemyLvl3TotalHeath;
			break;
		case 4:

			health = EnemyLvl4TotalHeath;
			break;
		case 5:

			health = EnemyLvl5TotalHeath;
			break;
		} // switch

		// return health
		return health;

	} // GetEnemyTotalHealth()


	/*=========================== GetEnemySpeed() ===================================================*/

	// return the speed for a certain level enemy
	public float GetEnemySpeed(int level){

		float speed = 0;

		switch (level) {
		case 1:

			speed = EnemyLvl1Speed;
			break;
		case 2:

			speed = EnemyLvl2Speed;
			break;
		case 3:

			speed = EnemyLvl3Speed;
			break;
		case 4:

			speed = EnemyLvl4Speed;
			break;
		case 5:

			speed = EnemyLvl5Speed;
			break;
		} // switch

		// return speed
		return speed;

	} // GetEnemySpeed()


	/*=========================== GetEnemyScore() ===================================================*/

	// return the score for a certain level enemy
	public int GetEnemyScore(int level){

		int score = 0;

		switch (level) {
		case 1:

			score = EnemyLvl1Score;
			break;
		case 2:

			score = EnemyLvl2Score;
			break;
		case 3:

			score = EnemyLvl3Score;
			break;
		case 4:

			score = EnemyLvl4Score;
			break;
		case 5:

			score = EnemyLvl5Score;
			break;
		} // switch

		// return score
		return score;

	} // GetEnemyScore()


} // class
