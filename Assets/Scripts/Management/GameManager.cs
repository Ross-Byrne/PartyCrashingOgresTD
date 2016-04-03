using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// Twitter

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";

	// UI
	private Text scoreText;
	private Button towerOneButton;
	private Button towerTwoButton;
	private Button towerThreeButton;
	private Button towerFourButton;
	private Button towerFiveButton;
	private Button settingsButton;

	// GameObjects
	public GameObject soundManager;
	public GameObject pathLayout;
	public Image castleHealthBar;
	public GameObject settingsMenu;
	public GameObject gamePromptPanel;
	public GameObject gameOverPanel;

	private SaveGameDataManager saveManager;
	private AudioSource audioSource;

	// sound effects
	public AudioClip finishingWave;
	public AudioClip castleDamaged;

	// Variables
	public bool GameHasStarted { get; set; }
	public int GameLevel {get; set; }
	public int GameScore { get; set; }
	public int EnemiesAlive { get; set; }
	private int castleHealth;
	private int totalCastleHealth;
	private float timeBetweenWaves = 10f;	// 30 seconds
	private bool gameOver = false;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// get a reference to the soundManager
		soundManager = GameObject.FindGameObjectWithTag("SoundManager");

		// flag scene as main
		soundManager.GetComponent<SoundManager>().isMainScene = true;

		// tell the sound manager to transition tracks to start playing main game music
		soundManager.GetComponent<SoundManager>().TransitionTracks();

		// get reference to gameManagers audio source
		audioSource = GetComponent<AudioSource>();

		// get references to UI

		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		towerOneButton = GameObject.Find ("TowerOneButton").GetComponent<Button>();
		towerTwoButton = GameObject.Find ("TowerTwoButton").GetComponent<Button>();
		towerThreeButton = GameObject.Find ("TowerThreeButton").GetComponent<Button>();
		towerFourButton = GameObject.Find ("TowerFourButton").GetComponent<Button>();
		towerFiveButton = GameObject.Find ("TowerFiveButton").GetComponent<Button>();
		settingsButton = GameObject.Find ("SettingsButton").GetComponent<Button>();

		// get reference to castle health bar image
		castleHealthBar = GameObject.Find("CastleHealthBar").GetComponent<Image>();

		// Initialise Variables

		GameLevel = 1;
		GameScore = 0;
		totalCastleHealth = 100;
		castleHealth = totalCastleHealth;

		// Setup the games UI
		SetUpUI();

		// instantiate the pathLayout
		pathLayout = (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/PathLayout1"));

		// get a reference to saveManager
		saveManager = GetComponent<SaveGameDataManager>();

	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start(){

		// load game data
		saveManager.Load();

		// start game
		GameHasStarted = true;

		// change to new sound clip

	} // Start()


	/*=========================== Update() ===================================================*/

	void Update () {

		// Update the UI

		// check if the score has changed
		if (GameScore != int.Parse(scoreText.text.Substring (7))) { // subString(7) to get rid of "Score: "

			// update the score
			scoreText.text = "Score: " + GameScore.ToString ();

		} // if

		// check if there arent any enemies and the game is not over
		if (EnemiesAlive == 0 && GameHasStarted == true && gameOver == false) {

			// if not last level
			if (GameLevel < 5) {

				// play if not the first level
				if (GameLevel > 1) {
					
					// set audioSource clip to wave finishing sound
					audioSource.clip = finishingWave;

					// play sound
					audioSource.Play ();

				} // if

				// move to next level
				GameLevel++;

				// start next wave
				StartCoroutine(StartNextWave());

				// to stop if triggering
				EnemiesAlive = -1;

			} else { // game is finished

				// game is over
				gameOver = true;

				// handle gameover
				GameOver ();

				Debug.Log ("It's Game Over!");

			} // if
		} // if
			
	} // Update()


	/*=========================== SetUpUI() ===================================================*/

	// sets up the games UI
	private void SetUpUI(){

		// add onClick listeners to the spawnTower buttons
		towerOneButton.onClick.AddListener (() => gameObject.GetComponent<DefenceTowerSpawner>().SpawnDefenceTower(1));
		towerTwoButton.onClick.AddListener (() => gameObject.GetComponent<DefenceTowerSpawner>().SpawnDefenceTower(2));
		towerThreeButton.onClick.AddListener (() => gameObject.GetComponent<DefenceTowerSpawner>().SpawnDefenceTower(3));
		towerFourButton.onClick.AddListener (() => gameObject.GetComponent<DefenceTowerSpawner>().SpawnDefenceTower(4));
		towerFiveButton.onClick.AddListener (() => gameObject.GetComponent<DefenceTowerSpawner>().SpawnDefenceTower(5));

		// add onclick method to settings button
		settingsButton.onClick.AddListener(() => SettingsButtonClick());

	} // SetUpUI()


	/*=========================== EnableDisableTowerUI() ===================================================*/

	// sets the spawn defence tower buttons to either interactable or not
	public void EnableDisableTowerUI(bool isInteractable){

		// sets the buttons to either interactable or not
		towerOneButton.interactable = isInteractable;
		towerTwoButton.interactable = isInteractable;
		towerThreeButton.interactable = isInteractable;
		towerFourButton.interactable = isInteractable;
		towerFiveButton.interactable = isInteractable;

	} // EnableDisableTowerUI()


	/*=========================== DamangeCastle() ===================================================*/

	// applies damage to the castle when an enemy gets destroyed at right border
	public void DamangeCastle(int damage){

		// decrease Castle Health
		castleHealth -= damage;

		// reduce castle health bar
		castleHealthBar.fillAmount = (float)castleHealth / totalCastleHealth;

		// set audioSource clip to damage sound
		audioSource.clip = castleDamaged;

		// play sound
		audioSource.Play ();

		if (castleHealth <= 0 && gameOver == false) {

			// its game over
			gameOver = true;

			// handle the gameover
			GameOver ();

			Debug.Log ("It's Game Over!");

		} // if

	} // DamangeCastle()


	/*=========================== StartNextWave() ===================================================*/

	// waits a certain amount of time and then starts the next wave
	IEnumerator StartNextWave(){

		int count = 0;
		GamePromptPanel gamePrompt;

		// get reference to the gamePromptPanel script
		gamePrompt = gamePromptPanel.GetComponent<GamePromptPanel>();

		// clear prompt text
		gamePrompt.promptText.text = "";

		// turn on game prompt panel
		gamePromptPanel.SetActive (true);

		// wait for next wave to start

		while (count < timeBetweenWaves && gameOver == false) {

			// print to count down timer on screen
			gamePrompt.promptText.text = "Wave Starts In: " + (timeBetweenWaves - count) + " Seconds. . .";

			Debug.Log("Time Til Next Wave: " + (timeBetweenWaves - count) + " Seconds.");

			// wait a second
			yield return new WaitForSeconds (1f);

			// increament count
			count++;

		} // while

		// check if the game is over
		if (gameOver == true) {

			// do nothing, the game is over

		} else {
			
			// start Next Wave
			StartCoroutine (GetComponent<EnemyWaveController> ().StartWave (GameLevel - 1));

			// clear prompt text
			gamePrompt.promptText.text = "";

			// turn off prompt
			gamePromptPanel.SetActive (false);

		} // if

	} // StartNextWave()


	/*=========================== GameOver() ===================================================*/

	// handles what happens when the game is over
	public void GameOver(){

		int count = 0;

		// clear game prompt text
		gamePromptPanel.GetComponent<GamePromptPanel>().promptText.text = "";

		// Deactivate the prompt panel
		gamePromptPanel.SetActive(false);

		// add the username and score to the leaderboard
		GetComponent<LeaderBoard>().Add(saveManager.usernames, saveManager.scores, saveManager.currentUsername, GameScore);

		// save the game data
		saveManager.Save();
	
		// set text on Game Over Panel
		gameOverPanel.GetComponent<GameOverPanel>().gameOverText.text = "Your Score is: " + GameScore;

		// activate GameOver Panel
		gameOverPanel.SetActive(true);

	} // GameOver()


	/*=========================== SettingsButtonClick() ===================================================*/

	// onclick method for settings button
	public void SettingsButtonClick(){

		// pause the game
		PauseGame(true);

		// open settings menu
		settingsMenu.SetActive(true);

		// make settings button non interactable
		settingsButton.interactable = false;

	} // SettingsButtonClick()


	/*=========================== BackToStartMenu() ===================================================*/

	// quits the game and returns to the startMenu
	public void BackToStartMenu(){

		// un pause game
		PauseGame(false);

		// flag scene as startMenu
		soundManager.GetComponent<SoundManager>().isMainScene = false;

		// tell the sound manager to transition tracks to start playing StartMenu music
		soundManager.GetComponent<SoundManager>().TransitionTracks();

		// go back to the Start Menu
		SceneManager.LoadScene("StartMenu");

	} // BackToStartMenu()


	/*=========================== PauseGame() ===================================================*/

	// takes a boolean that decides if the game should be paused or not
	public void PauseGame(bool pause){

		if (pause == true) { // pause game

			// pause game
			Time.timeScale = 0f;

			// start playing music again
			soundManager.GetComponent<SoundManager>().PauseMusic(pause);

		} else {	// unpause game

			// un pause game
			Time.timeScale = 1f;

			// start playing music again
			soundManager.GetComponent<SoundManager>().PauseMusic(pause);

		} // if

	} // PauseGame()


	/*=========================== ShareMessageToTwitter() ===================================================*/

	// Shares game score to Twitter
	// Found code to do this here: http://unity3dtrenches.blogspot.ie/2014/02/unity-3d-how-to-post-to-twitter-from.html
	public void ShareMessageToTwitter(){

		string message = "";

		// create message
		message = "I just got a Score of " + GameScore + " in Party Crashing Ogres Tower Defence!";

		// Share message to twitter
		Application.OpenURL(TWITTER_ADDRESS +
			"?text=" + WWW.EscapeURL(message) +
			"&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));

	} // ShareToTwitterClick()


} // class
