using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Script to manage the settings menu

public class SettingsMenu : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	public Button quitToMenuButton;
	public Button quitApplicationButton;
	public Button backButton;
	private GameObject gameManager;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// get referenece to gameManager
		gameManager = GameObject.FindGameObjectWithTag("GameManager");

		// add onclick methods to the buttons

		quitToMenuButton.onClick.AddListener (() => gameManager.GetComponent<GameManager>().BackToStartMenu());
		quitApplicationButton.onClick.AddListener (() => QuitAppButtonClick());
		backButton.onClick.AddListener (() => BackButtonClick());

		// 

	} // Awake()
		

	/*=========================== QuitAppButtonClick() ===================================================*/

	public void QuitAppButtonClick(){

		// un pause game
		Time.timeScale = 1f;

		// exit the application
		Application.Quit();

	} // QuitAppButtonClick()


	/*=========================== BackButtonClick() ===================================================*/

	public void BackButtonClick(){

		// un pause game
		Time.timeScale = 1f;

		// deactivate settings menu
		gameObject.SetActive(false);

		// make settings button interactable
		GameObject.Find("SettingsButton").GetComponent<Button>().interactable = true;

	} // BackButtonClick()


} // class
