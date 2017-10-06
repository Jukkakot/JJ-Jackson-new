using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{	
	void OnTriggerEnter(Collider col)
	{
		if (col.name.Equals ("JJ_Jackson")) {
			Player.inventory.Add (new GameItem (this.name, this.name));
			GameObject.Find (this.name).SetActive (false);
			if (this.name.Equals ("Map0")) {
				MainController.MapButtonVisibility ();
			}
		}
	}
}
