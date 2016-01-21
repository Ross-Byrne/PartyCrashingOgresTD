using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	/*=========================== Member Variables ===========================*/

	private string Type { get; set; }
	private string EnemyName { get; set; }
	private int Health { get; set; }
	private float Speed { get; set; }

	GameObject objectHit;

	private string walkingDirection = "";

	//public PolygonCollider2D pCollider;


	/*=========================== Methods ===========================*/

	/*=========================== Awake() ===========================*/

	void Awake() {

		// initialise variables

		// set speed
		Speed = 0.8f;

	} // Awake()


	/*=========================== Update() ===========================*/

	void Update(){

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
			
			Debug.Log ("Error, wrong path type");
			break;
		} // switch


	} // Update()
		

	/*=========================== OnTriggerEnter2D() ===========================*/

	// runs when a collision trigger is triggered, when an object enters collision with another object
	void OnTriggerEnter2D(Collider2D other){

		// check if the triggered collision is with A path tile
		if (other.tag == "PathTile") {

			// get the walking direction from the pathTile
			walkingDirection = other.gameObject.GetComponent<PathTile> ().PathType;

		} else { // if not on path tile

			// cancel walking direction
			walkingDirection = "";
		} // if

	} // OnTriggerEnter2D()



	/*=========================== MoveUp() ===========================*/

	// moves the enemy up
	private void MoveUp(){

		// move the enemy up
		transform.Translate (new Vector3 (0f, (this.Speed * Time.deltaTime), 0f));

	} // MoveUp()


	/*=========================== MoveDown() ===========================*/

	// moves the enemy down
	private void MoveDown(){

		// move the enemy down
		transform.Translate (new Vector3 (0f, (-this.Speed * Time.deltaTime), 0f));

	} // MoveDown()


	/*=========================== MoveLeft() ===========================*/

	// moves the enemy left
	private void MoveLeft(){

		// move the enemy left
		transform.Translate (new Vector3 ((-this.Speed * Time.deltaTime), 0f, 0f));

	} // MoveLeft()


	/*=========================== MoveRight() ===========================*/

	// moves the enemy right
	private void MoveRight(){

		// move the enemy right
		transform.Translate (new Vector3 (this.Speed * Time.deltaTime, 0f, 0f));

	} // MoveRight()

} // class
