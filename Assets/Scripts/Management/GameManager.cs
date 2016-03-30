using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// Prefabs
	private GameObject pathLayoutPrefab;


	// UI
	private Text scoreText;
	private Button towerOneButton;
	private Button towerTwoButton;
	private Button towerThreeButton;
	private Button towerFourButton;
	private Button towerFiveButton;


	// GameObjects
	public GameObject pathLayout;


	// Variables
	public int GameLevel {get; set; }

	public int gameScore;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// get reference to pathLayoutPrefab

		pathLayoutPrefab = (GameObject)Resources.Load ("Prefabs/PathLayout1");

		// get references to UI

		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		towerOneButton = GameObject.Find ("TowerOneButton").GetComponent<Button>();
		towerTwoButton = GameObject.Find ("TowerTwoButton").GetComponent<Button>();
		towerThreeButton = GameObject.Find ("TowerThreeButton").GetComponent<Button>();
		towerFourButton = GameObject.Find ("TowerFourButton").GetComponent<Button>();
		towerFiveButton = GameObject.Find ("TowerFiveButton").GetComponent<Button>();

		// Initialise Variables

		GameLevel = 1;
		gameScore = 0;

		// Setup the games UI
		SetUpUI();

		// instantiate the pathLayout
		pathLayout = (GameObject)Instantiate (pathLayoutPrefab);

	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start(){

		// spawn an enemy every 1 secs
		//GetComponent<EnemySpawner>().SpawnEnemy(2);

		// start game
		GetComponent<EnemyWaveController>().gameHasStarted = true;

	} // Start()


	/*=========================== Update() ===================================================*/

	void Update () {

		// Update the UI

		// check if the score has changed
		if (gameScore != int.Parse(scoreText.text.Substring (7))) { // subString(7) to get rid of "Score: "

			// update the score
			scoreText.text = "Score: " + gameScore.ToString ();

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


} // class
