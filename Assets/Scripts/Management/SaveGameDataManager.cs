using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

// Script to save game info such as high scores and username

public class SaveGameDataManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	private const int MAX_USER_SCORES = 10;

	// save the current username
	public string currentUsername;

	// save array of top 10 usernames
	public string[] usernames;

	// top 10 scores for users
	public int[] scores;


	/*=========================== Methods ===================================================*/

	void Awake(){

		// initial arrays
		usernames = new string[MAX_USER_SCORES];
		scores = new int[MAX_USER_SCORES];

	} // Awake()

	/*=========================== Save() ===================================================*/

	// saves game data to a file called PartyCrashingOgresTD.dat
	public void Save(){

		// save current username
		PlayerPrefs.SetString("currentUsername", currentUsername);

		// check that the arrays are the right size
		if (usernames.Length == MAX_USER_SCORES && scores.Length == MAX_USER_SCORES) {

			for (int i = 0; i < MAX_USER_SCORES; i++) {

				// save username
				PlayerPrefs.SetString ("User" + i, usernames [i]);

				// save score
				PlayerPrefs.SetInt ("Score" + i, scores [i]);

			} // for

			// save prefs
			PlayerPrefs.Save ();

		} else {

			Debug.Log ("ERROR, Arrays are not the correct size!");

			return;

		} // if

	} // Save()


	/*=========================== Load() ===================================================*/

	public void Load(){

		// check if there is a stored current username
		if (PlayerPrefs.HasKey ("currentUsername")) {

			// get current user
			currentUsername = PlayerPrefs.GetString ("currentUsername");

		} else { // otherwise

			// current user name is left blank
			currentUsername = "";

		} // if
			
		// check that the arrays are the right size
		if (usernames.Length == MAX_USER_SCORES && scores.Length == MAX_USER_SCORES) {

			// loop through to get usernames and scores
			for (int i = 0; i < MAX_USER_SCORES; i++) {

				// check if users and scores are there
				if (PlayerPrefs.HasKey ("User" + i.ToString()) && PlayerPrefs.HasKey ("Score" + i.ToString())) {

					// get value for username
					usernames [i] = PlayerPrefs.GetString ("User" + i.ToString());

					// get value for score
					scores [i] = PlayerPrefs.GetInt ("Score" + i.ToString());

				} else { // if highest user or score isn't there, no other ones after will be there after it.
					
					// return, nothing else saved
					return;

				} // if
			} // for

		} else {

			Debug.Log ("ERROR, Arrays are not the correct size!");

			return;

		} // if

	} // Load


} // class