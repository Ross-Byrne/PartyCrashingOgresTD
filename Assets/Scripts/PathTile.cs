using UnityEngine;
using System.Collections;

/**
 * 
 * 
 */

public class PathTile : MonoBehaviour {

	/*=========================== Member Variables ===========================*/
	[SerializeField]
	private string pathType;
	[SerializeField]

	public string PathType{

		get {  return pathType; }
		set { pathType = value; }
	} // PathType get/set

} // class
