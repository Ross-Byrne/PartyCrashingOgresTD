using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Script to manage the sound tracks in the game
// this object is a Singleton, to allow music to play properly between scenes

public class SoundManager : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	public static SoundManager soundManager;

	private AudioSource source;
	public AudioClip[] startMenuTracks;		// change to private
	public AudioClip[] mainGameTracks;		// change to private

	public bool isMainScene = false;
	private int currentPlayingClip;
	private float currentPlayingLength;
	private float curTime;
	private float timeSinceClipStarted;
	private float sourceVol = 0.3f;
	private bool transitioningTracks = false;


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	void Awake(){

		// to make sure only one version of SoundManager exisits
		// to enforce singleton patern
		if (soundManager == null) {

			// don't destroy gameobject when moving scenes
			DontDestroyOnLoad (gameObject);

			// set the reference to this object
			soundManager = this;

		} else if (soundManager != this) { // if the singleton already exists

			// destroy this object
			Destroy(gameObject);

		} // if

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
		if (curTime - timeSinceClipStarted >= currentPlayingLength - 0.4f && transitioningTracks == false) {

			// transition to next track
			TransitionTracks();

		} // if
			
	} // Update()


	/*=========================== PauseMusic() ===================================================*/

	// takes a boolean, decides to pause or un pause music
	public void PauseMusic(bool pause){

		if (pause == true) { // pause music

			// pause music
			source.Pause();

		} else { // unpause music

			// unpause music
			source.UnPause();

		} // if

	} // PauseMusic()


	/*=========================== TransitionTracks() ===================================================*/

	// transitions between two tracks
	public void TransitionTracks(){

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

		Debug.Log ("Now Playing: " + source.clip.name);

		// save the current time
		timeSinceClipStarted = Time.time;

		// fade in to playing clip
		StartCoroutine(FadeIn());

		// flag as finished transitioning between tracks
		transitioningTracks = false;
	
	} // TransitionTracks()


	/*=========================== FadeOut ===================================================*/

	// fades out from the current track playing
	IEnumerator FadeOut(){
		
		//Debug.Log ("Starting Fade out");

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

		//Debug.Log ("Finished Fade out");

	} // FadeOut()


	/*=========================== FadeIn() ===================================================*/

	// fades out from the current track playing
	IEnumerator FadeIn(){

		//Debug.Log ("Starting Fade In");

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

		//Debug.Log ("Finished Fade In");

	} // FadeIn()


} // class
