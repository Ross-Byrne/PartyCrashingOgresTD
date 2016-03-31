using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// UI
	private Text scoreText;
	private Button towerOneButton;
	private Button towerTwoButton;
	private Button towerThreeButton;
	private Button towerFourButton;
	private Button towerFiveButton;


	// GameObjects
	public GameObject pathLayout;
	public Image castleHealthBar;


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

		// get references to UI

		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		towerOneButton = GameObject.Find ("TowerOneButton").GetComponent<Button>();
		towerTwoButton = GameObject.Find ("TowerTwoButton").GetComponent<Button>();
		towerThreeButton = GameObject.Find ("TowerThreeButton").GetComponent<Button>();
		towerFourButton = GameObject.Find ("TowerFourButton").GetComponent<Button>();
		towerFiveButton = GameObject.Find ("TowerFiveButton").GetComponent<Button>();

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

	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start(){

		// spawn an enemy every 1 secs
		//GetComponent<EnemySpawner>().SpawnEnemy(2);

		// start game
		GameHasStarted = true;

	} // Start()


	/*=========================== Update() ===================================================*/

	void Update () {

		// Update the UI

		// check if the score has changed
		if (GameScore != int.Parse(scoreText.text.Substring (7))) { // subString(7) to get rid of "Score: "

			// update the score
			scoreText.text = "Score: " + GameScore.ToString ();

		} // if


		if (EnemiesAlive == 0 && GameHasStarted == true && gameOver == false) {

			Debug.Log ("Wave in Finished");

			// flag wave as over
			GetComponent<EnemyWaveController> ().waveOver = true;

			Debug.Log ("Wave Over");

			if (GameLevel < 5) {
				
				// move to next level
				GameLevel++;

				// start next wave
				StartCoroutine(StartNextWave());

				// to stop if triggering
				EnemiesAlive = -1;

			} else { // game is finished

				// game is over
				gameOver = true;

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

		if (castleHealth <= 0) {

			// its game over
			gameOver = true;

			Debug.Log ("It's Game Over!");

		} // if

	} // DamangeCastle()


	/*=========================== StartNextWave() ===================================================*/

	// waits a certain amount of time and then starts the next wave
	IEnumerator StartNextWave(){

		int count = 0;

		// wait for next wave to start

		while (count < timeBetweenWaves) {

			// print to count down timer on screen
			Debug.Log("Time Til Next Wave: " + (timeBetweenWaves - count) + " Seconds.");

			// wait a second
			yield return new WaitForSeconds (1f);

			// increament count
			count++;

		} // while

		// start Next Wave
		StartCoroutine(GetComponent<EnemyWaveController>().StartWave(GameLevel -1));

	} // StartNextWave()


} // class
