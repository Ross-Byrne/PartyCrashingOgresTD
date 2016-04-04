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
	//private int distBetweenPathTiles = 1;

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
		

} // class
