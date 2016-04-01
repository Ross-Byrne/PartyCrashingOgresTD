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
	private Button leaderboardButton;
	private Button quitButton;

	// save manager
	SaveGameDataManager saveManager;
	LeaderBoard leaderBoard;

	// Variables
	private string username;

	// for leaderboardPanel
	private float lbPanelWidth;
	private float lbPanelHeight;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// initialise variables

		lbPanelWidth = Screen.width * 0.28f; 	// width is 28% screen size
		lbPanelHeight = Screen.height * 0.72f; 	// height is 72% screen height

		// get reference to UI Elements
		usernameInput = GameObject.Find ("UsernameInputField").GetComponent<InputField>();
		playButton = GameObject.Find ("PlayButton").GetComponent<Button> ();
		leaderboardButton = GameObject.Find ("LeaderboardButton").GetComponent<Button>();
		quitButton = GameObject.Find ("QuitButton").GetComponent<Button>();

		// add play game button onclick method
		playButton.onClick.AddListener(() => PlayGame());

		// add leaderboard button onclick method
		leaderboardButton.onClick.AddListener(() => Leaderboard());

		// add quit button onclick method
		quitButton.onClick.AddListener(() => QuitGame());

		// get reference to saveManager
		saveManager = GetComponent<SaveGameDataManager>();

		// get reference to leaderboard
		leaderBoard = GetComponent<LeaderBoard>();

	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start(){

		// load game data
		saveManager.Load();

		// get current username
		usernameInput.text = saveManager.currentUsername;


		Debug.Log ("===================================================");

		// print out leaderboard
		leaderBoard.PrintLeaderBoard(saveManager.usernames, saveManager.scores);

		Debug.Log ("===================================================");

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


	/*=========================== Leaderboard() ===================================================*/

	// onclick method for the Leaderboard Button
	public void Leaderboard(){


		// instantiate leaderboard Prefab
		GameObject leaderboardPanel = (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/LeaderboardPanel"));

		// make leaderboardPanel inactive
		leaderboardPanel.SetActive(false);

		// get reference to canvas
		GameObject canvas = GameObject.Find("Canvas");

		// set canvas as leaderboards parent
		leaderboardPanel.transform.SetParent(canvas.transform);

		RectTransform r = leaderboardPanel.GetComponent<RectTransform> ();

		// set width and height
		r.sizeDelta = new Vector2(lbPanelWidth, lbPanelHeight);

		// anchor the UI Element to the center of the screen
		r.anchoredPosition = new Vector2 (0, 0);

		// set text on leaderboard
		leaderboardPanel.GetComponent<LeaderBoardPanel>().contentText.text = leaderBoard.PrintLeaderBoard(saveManager.usernames, saveManager.scores);

		// show the leaderboard panel
		leaderboardPanel.SetActive(true);

	} // Leaderboard()


	/*=========================== QuitGame() ===================================================*/

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
