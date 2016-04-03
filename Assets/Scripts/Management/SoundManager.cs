using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Script to manage the sound tracks in the game

public class SoundManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	AudioSource source;
	public AudioClip[] startMenuTracks;		// change to private
	public AudioClip[] mainGameTracks;		// change to private

	private int currentPlayingClip;
	private float currentPlayingLength;
	private bool isMainScene = false;
	private bool isPlayingMusic = true;
	private float curTime;
	private float timeSinceClipStarted;
	private float sourceVol = 0.4f;
	private bool transitioningTracks = false;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// get a reference to the audio source
		source = GameObject.Find("MusicPlayer").GetComponentInChildren<AudioSource> ();

		// set its volume
		source.volume = sourceVol;

		// reference clips

	} // Awake()


	/*=========================== Start() ===================================================*/

	void Start () {

		// start playing the audio
		TransitionTracks();


	} // Start()


	/*=========================== Update() ===================================================*/

	void Update(){

		// save current time
		curTime = Time.time;

		//Debug.Log ("curTime - timeSinceClipStarted: " + (curTime - timeSinceClipStarted));

		// check of the tracks need to the transitioned
		if (curTime - timeSinceClipStarted >= currentPlayingLength - 2f && transitioningTracks == false) {

			// transition to next track
			TransitionTracks();

		} // if


	} // Update()


	/*=========================== TransitionTracks() ===================================================*/

	// transitions between two tracks
	private void TransitionTracks(){

		// flag as transitioning between tracks
		transitioningTracks = true;

		// start to fade out of the playing clip
		StartCoroutine(FadeOut());

		// if main scene
		if (isMainScene == true) {

			// pick a random main track to play
			source.clip = mainGameTracks[Random.Range (0, mainGameTracks.Length)];

		} else { // if start scene

			// pick a random start menu track to play
			source.clip = startMenuTracks[Random.Range (0, startMenuTracks.Length)];

		} // if

		// save length of clip
		currentPlayingLength = source.clip.length;

		// play it
		source.Play ();

		Debug.Log ("Now Playing: " + source.clip.name + "Length = " + currentPlayingLength);

		// save the current time
		timeSinceClipStarted = Time.time;

		// fade in to playing clip
		StartCoroutine(FadeIn());

		// flag as finished transitioning between tracks
		transitioningTracks = false;
	
	} // TransitionTracks()


	// handles the contant playing of tracks
	IEnumerator PlayTracks(){

		while (isPlayingMusic) {
			
			// if main scene
			if (isMainScene == true) {

				// pick a random main track to play
				source.clip = mainGameTracks[Random.Range (0, mainGameTracks.Length)];

			} else { // if start scene

				// pick a random start menu track to play
				source.clip = startMenuTracks[Random.Range (0, startMenuTracks.Length)];

			} // if
				
			// save length of clip
			currentPlayingLength = source.clip.length;

			// play it
			source.Play ();

			// fade in to playing clip
			StartCoroutine(FadeIn());

			// wait length of the clip minus a second
			yield return new WaitForSeconds (currentPlayingClip - 1f);

			// start to fade out of the playing clip
			StartCoroutine(FadeOut());

		} // while

	} // PlayTracks()


	/*=========================== FadeOut ===================================================*/

	// fades out from the current track playing
	IEnumerator FadeOut(){
		
		Debug.Log ("Starting Fade out");

		// volume is equal to default source volume
		float vol = sourceVol;

		// keep looping while volume is greater then 0.1
		while (vol > 0.1) {

			// decrease volume by delta time
			vol -= Time.deltaTime;

			// set the source volume to the decreased amount
			source.volume = vol;

			// wait until the next frame
			yield return null;

		} // while

		Debug.Log ("Finished Fade out");

	} // FadeOut()


	/*=========================== FadeIn() ===================================================*/

	// fades out from the current track playing
	IEnumerator FadeIn(){

		Debug.Log ("Starting Fade In");

		// volume is off by default
		float vol = 0f;

		// keep looping while volume is less then default volume
		while (vol < sourceVol) {

			// increase volume by delta time
			vol += Time.deltaTime;

			// set the source volume to the increased amount
			source.volume = vol;

			// wait until the next frame
			yield return null;

		} // while

		Debug.Log ("Finished Fade In");

	} // FadeIn()


} // class
