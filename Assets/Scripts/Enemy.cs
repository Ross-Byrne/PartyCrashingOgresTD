using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	public string Type { get; set; }
	public string EnemyName { get; set; }
	public int TotalHealth { get; set; }
	public int Health { get; set; }
	public float Speed { get; set; }
	public int ScoreForKillingMe { get; set; }	// depends on enemy type
	public float XVelocity { get; set; }
	public float YVelocity { get; set; }

	public string walkingDirection = "";
	public bool isAtCenter = false;
	public GameObject objCollidedWith = null;

	private Image healthBar;
	public GameObject enemyBody;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake() {

		// get a reference to the health bar
		healthBar = gameObject.GetComponentInChildren<Image>();

		// initialise variables
		ScoreForKillingMe = 10;

		// set speed
		Speed = 0.8f;

		// set health
		TotalHealth = 2;
		Health = TotalHealth;

		XVelocity = 0f;
		YVelocity = 0f;

	} // Awake()


	/*=========================== Update() ===================================================*/

	void Update(){

		// if the enemy is at the center of the tile, keep moving them in correct direction
		if (isAtCenter) {
			
			// make the enemy walk
			switch (walkingDirection) {
			case "Up": // if tile direction is up

			// move the enemy up
				MoveUp ();
				break;
			case "Down": // if tile direction is Down
			
			// move the enemy down
				MoveDown ();
				break;
			case "Left": // if tile direction is Left

			// move the enemy Left
				MoveLeft ();
				break;
			case "Right": // if tile direction is Right

			// move the enemy right
				MoveRight ();
				break;
			default:
			
				Debug.Log ("Error, wrong path type: " + walkingDirection);
				break;

			} // switch

		} else { // if not at the center of tile

			if(objCollidedWith != null) {
				
				// move the enemy towards the center of the tile
				transform.position = Vector3.MoveTowards (transform.position, objCollidedWith.transform.position, Speed * Time.deltaTime);

				// check if the enemy is aprox at the center of the tile
				if (Vector3.Distance(gameObject.transform.position, objCollidedWith.transform.position) < 0.001f) {

					// set enemies position to center of the tile
					transform.position = objCollidedWith.transform.position;

					// flag enemy as at the center
					isAtCenter = true;

					// set object collided with to null b/c finished
					objCollidedWith = null;

				} // if
			} // if
		} // if
			
	} // Update()
		

	/*=========================== OnTriggerEnter2D() ===================================================*/

	// runs when a collision trigger is triggered, when an object enters collision with another object
	void OnTriggerEnter2D(Collider2D other){

		// check if the triggered collision is with A path tile
		if (other.tag == "PathTile") {

			// enemy is not at center of the tile
			isAtCenter = false;

			// get reference to object collided with
			objCollidedWith = other.gameObject;

			// get the walking direction from the pathTile
			walkingDirection = other.gameObject.GetComponent<PathTile> ().PathType;

		} // if

		// if projectile
		if (other.tag == "Projectile") {

			// reduce health by projectile damage
			Health -= other.GetComponent<Projectile>().projectileDamage;

			Debug.Log ("Projectile damage: " + other.GetComponent<Projectile>().projectileDamage);

			// destroy the projectile
			if(other.gameObject != null)
				Destroy (other.gameObject);

			// decrease health bar by calculating % of total health
			healthBar.fillAmount = (float)Health / TotalHealth;

			// if enemies health is gone
			if (Health <= 0) {

				// kill the enemy
				KillEnemy ();

			} // if

		} // if

	} // OnTriggerEnter2D()


	/*=========================== KillEnemy() ===================================================*/

	// handles the killing of an enemy
	private void KillEnemy(){

		// add the score for being killed
		GameObject.Find("_GameManager").GetComponent<GameManager>().gameScore += ScoreForKillingMe;

		// kill the enemy
		Destroy (gameObject);

	} // KillEnemy()


	/*=========================== MoveEnemy() ===================================================*/

	// moves the enemy according to set velocity
	private void MoveEnemy(float XVelocity, float YVelocity){

		// move the enemy
		transform.Translate (new Vector3 (XVelocity, YVelocity, 0f));

	} // MoveEnemy()


	/*=========================== MoveUp() ===================================================*/

	// moves the enemy up
	private void MoveUp(){

		// record X and Y velocity
		XVelocity = 0f;
		YVelocity = (this.Speed * Time.deltaTime);

		// rotate enemy body to 0, 0, 90
		enemyBody.transform.eulerAngles = new Vector3(0f, 0f, 90f);
			
		// move the enemy up
		MoveEnemy(XVelocity, YVelocity);

	} // MoveUp()


	/*=========================== MoveDown() ===================================================*/

	// moves the enemy down
	private void MoveDown(){

		// record X and Y velocity
		XVelocity = 0f;
		YVelocity = (-this.Speed * Time.deltaTime);

		// rotate enemy body to 0, 0, -90
		enemyBody.transform.eulerAngles = new Vector3(0f, 0f, -90f);

		// move the enemy down
		MoveEnemy(XVelocity, YVelocity);

	} // MoveDown()


	/*=========================== MoveLeft() ===================================================*/

	// moves the enemy left
	private void MoveLeft(){

		// record X and Y velocity
		XVelocity = (-this.Speed * Time.deltaTime);
		YVelocity = 0f;

		// rotate enemy body to 0, 0, 180
		enemyBody.transform.eulerAngles = new Vector3(0f, 0f, 180f);

		// move the enemy left
		MoveEnemy(XVelocity, YVelocity);

	} // MoveLeft()


	/*=========================== MoveRight() ===================================================*/

	// moves the enemy right
	private void MoveRight(){

		// record X and Y velocity
		XVelocity = (this.Speed * Time.deltaTime);
		YVelocity = 0f;

		// rotate enemy body to 0, 0, 0
		enemyBody.transform.eulerAngles = new Vector3(0f, 0f, 0f);

		// move the enemy right
		MoveEnemy(XVelocity, YVelocity);

	} // MoveRight()


} // class
