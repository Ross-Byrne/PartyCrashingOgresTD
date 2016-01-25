using UnityEngine;
using System.Collections;

// destroys any object that collides with it

public class ObjectDestroyer : MonoBehaviour {

	/*=========================== Methods ===================================================*/

	/*=========================== OnTriggerEnter2D() ===================================================*/

	// runs when a collision trigger is triggered, when an object enters collision with another object
	void OnTriggerEnter2D(Collider2D other){

		// destroy object
		Destroy (other.gameObject);

	} // OnTriggerEnter2D()


} // class
