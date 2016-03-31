using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

// Script to save game info such as high scores and username

public class SaveGameDataManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	private static string FILE_NAME = "PartyCrashingOgresTD.dat";

	// save the current username
	public string currentUsername;

	// save the collection of usenames and their scores
	public Dictionary<string, int> highScores = new Dictionary<string, int>(10);

	private string[] usernames;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// adds all dictionary keys to array
		//userScores.Keys.CopyTo (usernames, 0);

	} // Awake()


	/*=========================== Save() ===================================================*/

	// saves game data to a file called PartyCrashingOgresTD.dat
	public void Save(){

		// save current username
		PlayerPrefs.SetString("currentUsername", currentUsername);

		// save prefs
		PlayerPrefs.Save();

	} // Save()


	/*=========================== Load() ===================================================*/

	public void Load(){

		// check if there is a stored current username
		if (PlayerPrefs.HasKey ("currentUsername")) {

			// get current user
			currentUsername = PlayerPrefs.GetString("currentUsername");

		}

	} // Load


} // class