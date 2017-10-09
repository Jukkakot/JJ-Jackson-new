using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC: MonoBehaviour
{
	private bool clickable = false;

	public void OnTriggerEnter(Collider col)
	{	
		if (col.name.Equals ("JJ_Jackson")) {
			
			Debug.Log ("You're close to " + this.name);
			clickable = true;
		}
	}

	public void OnMouseDown()
	{
		if (clickable) {
			GameObject.Find (this.name).GetComponent<DialogueTrigger> ().TriggerDialogue ();
		}
	}

	void OnTriggerExit(Collider col)
	{	
		if (col.name.Equals ("JJ_Jackson")) {
			Debug.Log ("You left " + this.name);
			clickable = false;
	}
}
}


