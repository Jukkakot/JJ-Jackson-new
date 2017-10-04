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
			Debug.Log ("You left " + this.name);
			clickable = false;
	}
}


