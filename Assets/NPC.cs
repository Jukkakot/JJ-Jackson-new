using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC: MonoBehaviour
{
	private bool clickable = false;

	public void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "JJ_Jackson")
		{
			Debug.Log ("You're close to NPC");
			clickable = true;
		}
	}

	public void OnMouseDown()
	{
		if (!clickable)
		{
			return;
		}

		Debug.Log ("You clicked me");
		FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name == "JJ_Jackson")
		{
			clickable = false;
		}
	}
}


