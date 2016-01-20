using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	/*=========================== Member Variables ===========================*/

	private string Type { get; set; }
	private string EnemyName { get; set; }
	private int Health { get; set; }
	private float Speed { get; set; }

	GameObject objectHit;

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

		// move enemy up
		MoveRight();


	} // Update()


		
	void OnCollisionEnter2D(Collision2D coll){

		//objectHit = coll.collider.gameObject;

		//Debug.Log(objectHit.GetComponent<PathTile> ().PathType);

		if (coll.gameObject.tag == "PathTile") {

			print ("Collision");
		}
		Debug.Log ("Collision");

	}




	/*=========================== MoveUp() ===========================*/

	// moves the enemy up
	private void MoveUp(){

		// move the enemy up
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + (this.Speed * Time.deltaTime), 0f);

	} // MoveUp()


	/*=========================== MoveDown() ===========================*/

	// moves the enemy down
	private void MoveDown(){

		// move the enemy down
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - (this.Speed * Time.deltaTime), 0f);

	} // MoveDown()


	/*=========================== MoveLeft() ===========================*/

	// moves the enemy left
	private void MoveLeft(){

		// move the enemy left
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x - (this.Speed * Time.deltaTime), gameObject.transform.position.y, 0f);

	} // MoveLeft()


	/*=========================== MoveRight() ===========================*/

	// moves the enemy right
	private void MoveRight(){

		// move the enemy right
		transform.Translate (new Vector3 (this.Speed * Time.deltaTime, 0f, 0f));

	} // MoveRight()

} // class
