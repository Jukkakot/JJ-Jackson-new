using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC: MonoBehaviour
{
	private bool clickable = false;

	public void OnTriggerEnter(Collider col)
	{
			Debug.Log ("You're close to "+this.name);
			clickable = true;
	}

	public void OnMouseDown()
	{
		if (clickable)
		{
			Debug.Log ("You clicked me");
			FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
		}
	}

	void OnTriggerExit(Collider col)
	{
			Debug.Log ("You left " + this.name);
			clickable = false;
	}
}


