using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{	
	void OnTriggerEnter(Collider col)
	{
		Player.inventory.Add (new GameItem (this.name, this.name));
		GameObject.Find (this.name).SetActive (false);
	}
}
