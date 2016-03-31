using UnityEngine;
using System.Collections;

// destroys any object that collides with it

public class ObjectDestroyer : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	private GameObject gameManager;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// get reference to gameManager
		gameManager = GameObject.FindGameObjectWithTag("GameManager");

	} // Awake()


	/*=========================== OnTriggerEnter2D() ===================================================*/

	// runs when a collision trigger is triggered, when an object enters collision with another object
	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Enemy"){

			// check if object destroyer is right destroyer
			if (gameObject.name == "ObjectDestroyerRight") {

				// Damage Castle Health
				gameManager.GetComponent<GameManager>().DamangeCastle(other.GetComponent<Enemy>().ScoreForKillingMe);

			} // if

		} // if

		// destroy object
		Destroy (other.gameObject);

	} // OnTriggerEnter2D()


} // class
