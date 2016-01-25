using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	GameObject defenceTower;
	GameObject target = null;

	float projectileSpeed = 3f;


	void Start () {
	
		defenceTower = gameObject.GetComponentInParent<DefenceTower> ().defenceTower;

		target = defenceTower.GetComponent<DefenceTower> ().enemyTarget;

	} // Start()


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
