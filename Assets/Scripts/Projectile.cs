using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	GameObject defenceTower;
	GameObject target;
	Animator anim;
	bool animationFinished = false;

	float projectileSpeed = 0f;
	public int projectileDamage = 0;


	/*=========================== Methods ===================================================*/

	/*=========================== Start() ===================================================*/

	void Start () {
	
		// get reference to DefenceTower object
		defenceTower = gameObject.GetComponentInParent<DefenceTower> ().defenceTower;

		// set the projectile speed
		projectileSpeed = defenceTower.GetComponent<DefenceTower>().projectileSpeed;

		// set projectile damage
		projectileDamage = defenceTower.GetComponent<DefenceTower>().projectileDamage;

		// get the reference to the target enemy
		target = defenceTower.GetComponent<DefenceTower> ().enemyTarget;

		// set animation to not finished
		animationFinished = false;

		// get reference to animator
		anim = GetComponent<Animator>();

		if (defenceTower.tag == "TowerLvl4") {

			// run animation Projectile gets bigger
			anim.Play("ProjectileGetsBigger", 0, 0f);

		} else { // if not lvl 4 tower

			// animation does not play
			animationFinished = true;

		} // if

	} // Start()


	/*=========================== Update() ===================================================*/

	// Update is called once per frame
	void Update () {

		if(animationFinished == true){
			
			// if there is a target object
			if (target != null) {

				// fire projectile at target
				transform.position = Vector3.MoveTowards (transform.position, target.transform.position, projectileSpeed * Time.deltaTime);

			} else { // if no target object

				// destroy projectile
				Destroy(gameObject);

			} // if
		} // if
	
	} // Update()


	/*=========================== BiggerAnimFinished() ===================================================*/

	// runs when the projectile gets bigger animation is finished
	public void BiggerAnimFinished(){

		// flag animation as finished
		animationFinished = true;

	} // BiggerAnimFinished()


	public void TurnOnBlast(){

		GetComponentInChildren<ParticleSystem> ().Play ();

	}

} // class
