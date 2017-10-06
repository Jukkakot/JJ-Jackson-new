using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC: MonoBehaviour
{
	private bool clickable = false;

	public void OnTriggerEnter(Collider col)
	{
		if (col.name.Equals ("JJ_Jackson")) {
			Debug.Log (col.name + " is close to " + this.name);
			clickable = true;
		}
	}

	public void OnMouseDown()
	{
		Player.updateStringInventory ();
		if (clickable)
		{	Debug.Log ("You clicked " + this.name);
			
			if (this.name.Equals ("NPCTent") && !Player.stringInventory.Contains ("Letter")) {
				Player.inventory.Add (new GameItem ("Letter", "Letter"));
				FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
			}
			else {
				FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
			}
		} 
	}

	void OnTriggerExit(Collider col)
	{
		if (col.name.Equals ("JJ_Jackson")) {
			Debug.Log (col.name + " left " + this.name);
			clickable = false;
		}
	}
}


