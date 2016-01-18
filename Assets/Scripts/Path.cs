using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	/*=========================== Member Variables ===========================*/

	// Prefabs

	public GameObject pathTilePrefab;

	// Variables

	GameObject tempPathTile;

	private int NumOfTiles { get; set; }
	private List<GameObject> pathTileList;

	private int xStartPos = -5;
	private int yStartPos = 0;

	// the distance between the path tiles 

	private int distBetweenPathTiles = 1;


	/*=========================== Methods ===========================*/

	/*=========================== Awake() ===========================*/

	// initialise
	void Awake () {

		// set number of path tiles to 10;
		NumOfTiles = 10;
	
		// initialise the pathTileList
		pathTileList = new List<GameObject>();

		// in a loop, instantiate the pathTile game objects from a prefab
		for (int i = 0; i < NumOfTiles; i++) {

			// instantiate the path tile object
			tempPathTile = (GameObject)Instantiate (pathTilePrefab);

			// set the position of the path tile
			tempPathTile.transform.position = new Vector3 (xStartPos + (distBetweenPathTiles * i), yStartPos, 0);

			// make the path tile a child of Path
			tempPathTile.transform.SetParent (gameObject.transform, false);

		} // for


	} // Awake()


} // class
