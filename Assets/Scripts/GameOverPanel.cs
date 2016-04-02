using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// script that manages the Game Over Panel

public class GameOverPanel : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	public Text gameOverText;
	public Button shareToTwitterButton;
	public Button backToStartButton;
	private GameManager gameManager;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake () {
	
		// add onclick methods to the buttons
		shareToTwitterButton.onClick.AddListener (() => ShareToTwitterClick());
		backToStartButton.onClick.AddListener (() => BackToStartClick());

		// get reference to GameManager
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

	} // Awake()


	/*=========================== ShareToTwitterClick() ===================================================*/

	// onclick method for share to twitter button
	public void ShareToTwitterClick(){

		// share score to twitter
		gameManager.ShareMessageToTwitter();

	} // ShareToTwitterClick()


	/*=========================== BackToStartClick() ===================================================*/

	// onclick method for the back to start button
	public void BackToStartClick(){

		// go back to start menu scene
		SceneManager.LoadScene("StartMenu");

	} // BackToStartClick()


} // class
