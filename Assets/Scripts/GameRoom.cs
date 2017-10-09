using System;
using UnityEngine;
using System.Collections.Generic;

public class GameRoom: MonoBehaviour
{
	List<Vector3> locations = new List<Vector3>();
	Dictionary<string, Vector3> locationCollection = new Dictionary<string, Vector3>();

	public GameRoom()
	{
		locations.Add (new Vector3 (0, 0, 0));
		locations.Add (new Vector3 (62, 88, 443));
		locations.Add (new Vector3 (-23, -23, -23));


		locationCollection.Add ("Beginning", locations [0]);
		locationCollection.Add ("Space", locations [1]);
		locationCollection.Add ("Desert", locations [2]);
	}
	public Vector3 GetLocation(string locationName)
	{
		return locationCollection [locationName];
	}

}


