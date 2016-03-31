using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script to manage the starting of the game

public class StartGame : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// UI
	private InputField usernameInput;
	private Button playButton;
	private Button quitButton;


	// Variables
	private string username;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// get reference to UI Elements
		usernameInput = GameObject.Find ("UsernameInputField").GetComponent<InputField>();
		playButton = GameObject.Find ("PlayButton").GetComponent<Button> ();
		quitButton = GameObject.Find ("QuitButton").GetComponent<Button>();

		// add
		quitButton.onClick.AddListener(() => QuitGame());

	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start () {
	
	} // Start()


	/*=========================== Update() ===================================================*/

	void Update () {
	
	} // Update


	public void PlayGame(){

		// load next scene

	} // PlayGame()


	public void QuitGame(){

		// quit the game
		Application.Quit ();

	} // QuitGame()

} // class
