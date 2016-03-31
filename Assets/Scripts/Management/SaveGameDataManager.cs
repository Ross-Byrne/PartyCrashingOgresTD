using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
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

		BinaryFormatter bf = new BinaryFormatter ();

		// Creates new Save file
		FileStream file = File.Create(Application.persistentDataPath + FILE_NAME);

		// Creates new object to hold games data
		GameData data = new GameData ();

		// Save games data to GameData Object

		// save current username
		data.username = currentUsername;

		// save dictionary of usernames and high scores
		data.highScores = highScores;

		// save gamedata object to file
		bf.Serialize (file, data);

		// close file
		file.Close ();

	} // Save()


	/*=========================== Load() ===================================================*/

	public void Load(){

		// if the file exists
		if (File.Exists (Application.persistentDataPath + FILE_NAME)) {

			BinaryFormatter bf = new BinaryFormatter ();

			// opens save game file
			FileStream file = File.Open (Application.persistentDataPath + FILE_NAME, FileMode.Open);

			// makes gamedata object with saved game data
			GameData data = (GameData)bf.Deserialize (file);

			// close file
			file.Close ();

			try {

				// load current username
				currentUsername = data.username;

				// load high scores
				highScores = data.highScores;

			} catch (Exception e) { // if loading fails
				
				// prints exception message
				Debug.Log (e);

				// default username
				currentUsername = "";

				// default dictionary (empty)
				highScores = new Dictionary<string, int> (10);

			} // try catch

		} else {	// if save file doesnt exsist

			Debug.Log("File Does Not Exist!");

			// default username
			currentUsername = "";

			// default dictionary (empty)
			highScores = new Dictionary<string, int> (10);

		} // if

	} // Load


} // class


/*=========================== GameData Class ===================================================*/

// Class for holding all game data to make a save game
[Serializable]
class GameData{

	// save the current username
	public string username;

	// save the collection of usenames and their scores
	public Dictionary<string, int> highScores = new Dictionary<string, int>(10);


} // class