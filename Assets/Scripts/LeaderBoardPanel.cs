using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderBoardPanel : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	public Text contentText;
	public Button okButton;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// add onclick method to button
		okButton.onClick.AddListener(() => OK());

	} // Awake()


	/*=========================== OK() ===================================================*/

	// onclick method for the ok button
	public void OK(){

		// delete game object
		Destroy(gameObject);

	} // OK()


} // class

