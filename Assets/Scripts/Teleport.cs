using System;
using UnityEngine;
using System.Collections;

public class Teleport: MonoBehaviour
{
	//Coordinates that are used as the destination for teleportation.
	public Transform destination;
	
	//A list of tags. Only one tag needed, for now.
	public string tagList = "|Player|";

	//This is called when entering the teleport.
	void OnTriggerEnter(Collider col)
	{	
		//Checks if the colliding object is the player.
		if (tagList.Contains (string.Format ("|{0}|", col.tag)))
		{
			//Teleports the player to destination.
			col.transform.position = destination.transform.position;
		}
	}
}
