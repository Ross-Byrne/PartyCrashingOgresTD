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

		for (int i = 0; i < usernames.Length; i++) {

			// save username
			PlayerPrefs.SetString("User" + i, usernames[i]);

		} // for
			
		for (int i = 0; i < scores.Length; i++) {

			// save score
			PlayerPrefs.SetInt("Score" + i, scores[i]);

		} // for

		// save prefs
		PlayerPrefs.Save();

	} // Save()


	/*=========================== Load() ===================================================*/

	public void Load(){

		// check if there is a stored current username
		if (PlayerPrefs.HasKey ("currentUsername")) {

			// get current user
			currentUsername = PlayerPrefs.GetString("currentUsername");

		} // if
			
		// loop through to get users
		for (int i = 0; i < MAX_USER_SCORES; i++) {

			// check if users are there
			if (PlayerPrefs.HasKey ("User" + i.ToString())) {

				// get value
				usernames [i] = PlayerPrefs.GetString ("User" + i.ToString());

			} else { // if highest user isn't there, no other ones after will be there etc.

				// break out of loop
				break;

			} // if
		} // for

		// loop through to get high scores
		for (int i = 0; i < MAX_USER_SCORES; i++) {

			// check if scores are there
			if (PlayerPrefs.HasKey ("Score" + i.ToString())) {

				// get value
				scores [i] = PlayerPrefs.GetInt ("Score" + i.ToString());

			} else { // if highest score isn't there, no other ones after will be there etc.

				// break out of loop
				break;

			} // if
		} // for

	} // Load


} // class