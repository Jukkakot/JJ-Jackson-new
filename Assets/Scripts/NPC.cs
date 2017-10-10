using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC: MonoBehaviour
{
	private bool clickable = false;

	public void OnTriggerEnter(Collider col)
	{	
		if (col.name.Equals ("JJ_Jackson")) {
			clickable = true;
		}
		if (col.name.Equals ("JJ_Jackson") && this.name.Equals ("Text trigger")) {
				GameObject.Find (this.name).GetComponent<DialogueTrigger> ().TriggerDialogue ();
			Player.hasTalkedToVP = true;
		}
	}

	public void OnMouseDown()
	{
		Player.updateStringInventory ();
		if (clickable) {
			if (this.name.Equals ("NPCCity") && !Player.stringInventory.Contains ("Map")) {
				Player.inventory.Add (new GameItem ("Map", "Map"));
				MainController.MapButtonVisibility ();
				GameObject.Find (this.name).GetComponent<DialogueTrigger> ().TriggerDialogue ();
			}
		}
	}

	void OnTriggerExit(Collider col)
	{	
		if (col.name.Equals ("JJ_Jackson")) {
			clickable = false;
	}
}
}


