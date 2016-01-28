using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	GameObject defenceTower;
	GameObject target;

	float projectileSpeed = 0f;


	/*=========================== Methods ===================================================*/

	/*=========================== Start() ===================================================*/

	void Start () {
	
		// get reference to DefenceTower object
		defenceTower = gameObject.GetComponentInParent<DefenceTower> ().defenceTower;

		// set the projectile speed
		projectileSpeed = defenceTower.GetComponent<DefenceTower>().projectileSpeed;

		// get the reference to the target enemy
		target = defenceTower.GetComponent<DefenceTower> ().enemyTarget;

	} // Start()


	/*=========================== Update() ===================================================*/

	// Update is called once per frame
	void Update () {

		// if there is a target object
		if (target != null) {

			// fire projectile at target
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, projectileSpeed * Time.deltaTime);

		} else { // if no target object

			// destroy projectile
			Destroy(gameObject);

		} // if
	
	} // Update()


} // class
