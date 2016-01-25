using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	/*=========================== Member Variables ===================================================*/

	// Variables

	private int NumOfTiles { get; set; }
	[SerializeField]
	private List<GameObject> pathTileList;

	// the distance between the path tiles 
	private int distBetweenPathTiles = 1;

	// keeping track of starting and ending points on path
	[SerializeField]
	private GameObject pathStart;
	[SerializeField]
	private GameObject pathFinish;

	public GameObject PathStart{

		get {  return pathStart; }
		set { pathStart = value; }
	}

	public GameObject PathFinish{

		get {  return pathFinish; }
		set { pathFinish = value; }
	}


	/*=========================== Methods ===================================================*/

	/*=========================== Awake() ===================================================*/

	// initialise
	void Awake () {

	/*	// set number of path tiles to 10;
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

			// add the pathTile to the list
			pathTileList.Add(tempPathTile);

		} // for
		*/

	} // Awake()


} // class
