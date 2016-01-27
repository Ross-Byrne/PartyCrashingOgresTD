using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	private string Type { get; set; }
	private string EnemyName { get; set; }
	private int Health { get; set; }
	private float Speed { get; set; }
	private int ScoreForKillingMe { get; set; }	// depends on enemy type

	private string walkingDirection = "";
	private bool isAtCenter = false;
	private GameObject objCollidedWith = null;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake() {

		// initialise variables
		ScoreForKillingMe = 10;

		// set speed
		Speed = 1.4f;

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

			// destroy the projectile
			Destroy (other.gameObject);

			// add the score for being killed
			GameObject.Find("_GameManager").GetComponent<GameManager>().gameScore += ScoreForKillingMe;

			// kill the enemy
			Destroy (gameObject);

		} // if

	} // OnTriggerEnter2D()


	/*=========================== MoveUp() ===================================================*/

	// moves the enemy up
	private void MoveUp(){

		// move the enemy up
		transform.Translate (new Vector3 (0f, (this.Speed * Time.deltaTime), 0f));

	} // MoveUp()


	/*=========================== MoveDown() ===================================================*/

	// moves the enemy down
	private void MoveDown(){

		// move the enemy down
		transform.Translate (new Vector3 (0f, (-this.Speed * Time.deltaTime), 0f));

	} // MoveDown()


	/*=========================== MoveLeft() ===================================================*/

	// moves the enemy left
	private void MoveLeft(){

		// move the enemy left
		transform.Translate (new Vector3 ((-this.Speed * Time.deltaTime), 0f, 0f));

	} // MoveLeft()


	/*=========================== MoveRight() ===================================================*/

	// moves the enemy right
	private void MoveRight(){

		// move the enemy right
		transform.Translate (new Vector3 (this.Speed * Time.deltaTime, 0f, 0f));

	} // MoveRight()


} // class
