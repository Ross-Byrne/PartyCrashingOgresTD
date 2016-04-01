using UnityEngine;
using System.Collections;

// Script to sort scores into order on a leader board

public class LeaderBoard : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	private const int MAX_USER_SCORES = 10;


	/*=========================== Methods ===================================================*/

	/*=========================== Add() ===================================================*/

	// adds a username and score to the leader board in the correct place.
	public void Add(string[] usernames, int[] scores, string name, int score){

		// check the arrays are of correct length
		if (usernames.Length == MAX_USER_SCORES && scores.Length == MAX_USER_SCORES) {

			// loop backwards through scores from the last score to the first
			for (int i = MAX_USER_SCORES -1; i > -1; i--) {

				// check if the score is greater
				if (score > scores [i]) {

					// if last leader board entry
					if (i == MAX_USER_SCORES - 1) {

						// replace last entry
						usernames [i] = name;
						scores [i] = score;

					} else { // if not last 

						// move current score down the array by one element
						usernames[i + 1] = usernames[i];
						scores [i + 1] = scores [i];

						// add score into its place
						usernames[i] = name;
						scores [i] = score;

					} // if
				} // if 
			} // for

		} else {

			Debug.Log ("ERROR, Arrays not correct size!");

			return;
		} // if

	} // Add()


	/*=========================== PrintLeaderBoard() ===================================================*/

	// prints leaderboard into console
	public void PrintLeaderBoard(string[] usernames, int[] scores){

		if(usernames.Length == MAX_USER_SCORES && scores.Length == MAX_USER_SCORES){

			// loop through arrays
			for(int i = 0; i < MAX_USER_SCORES; i++){

				// print out content into console
				Debug.Log ((i + 1) + ": Username: " + usernames[i] + " Score: " + scores[i]);

			} // for

		} else {

			Debug.Log ("ERROR, Arrays not correct size!");

			return;
		} // if

	} // PrintLeaderBoard()

} // class
