using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Script to manage the starting of the game

public class StartGame : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// UI
	private InputField usernameInput;
	private Button playButton;
	private Button quitButton;

	// save manager
	SaveGameDataManager saveManager;

	// Variables
	private string username;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// get reference to UI Elements
		usernameInput = GameObject.Find ("UsernameInputField").GetComponent<InputField>();
		playButton = GameObject.Find ("PlayButton").GetComponent<Button> ();
		quitButton = GameObject.Find ("QuitButton").GetComponent<Button>();

		// add play game button onclick method
		playButton.onClick.AddListener(() => PlayGame());

		// add quit button onclick method
		quitButton.onClick.AddListener(() => QuitGame());

		// get reference to saveManager
		saveManager = GetComponent<SaveGameDataManager>();

		// load game data
		saveManager.Load();

		// get current username
		usernameInput.text = saveManager.currentUsername;

	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start(){



	} // Start()


	/*=========================== PlayGame() ===================================================*/

	// onclick method for PlayGame Button
	public void PlayGame(){

		// update current username
		saveManager.currentUsername = usernameInput.text;

		// save game data
		saveManager.Save ();

		// load main scene
		SceneManager.LoadScene("Main");

	} // PlayGame()


	/*=========================== Update() ===================================================*/

	// onclick method for QuitGame Button
	public void QuitGame(){

		// update current username
		saveManager.currentUsername = usernameInput.text;

		// save game data
		saveManager.Save ();

		// quit the game
		Application.Quit ();

	} // QuitGame()


} // class
