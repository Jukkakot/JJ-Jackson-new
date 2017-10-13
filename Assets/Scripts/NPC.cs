using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC: MonoBehaviour
{
	//Every NPC is unclickable until the player enters their perimeter.
	private bool clickable = false;
	
	//Called when the player enters the object's collision area.
	public void OnTriggerEnter(Collider col)
	{	
		//Checks if the object colliding is the player.
		if (col.name.Equals ("JJ_Jackson"))
		{
			//Makes it possible to click the NPC.
			clickable = true;
		}
		//This is called to trigger the final event.
		if (col.name.Equals ("JJ_Jackson") && this.name.Equals ("Text trigger"))
		{
			GameObject.Find (this.name).GetComponent<DialogueTrigger> ().TriggerDialogue ();
			Player.hasTalkedToVP = true;
		}
	}
	//Called when clicking a clickable NPC.
	public void OnMouseDown()
	{
		//Updates the player's inventory.
		Player.updateStringInventory ();
		if (clickable)
		{
			//Checking if a specific NPC is talked to and if there's no map already in inventory.
			if (this.name.Equals ("NPCCity") && !Player.stringInventory.Contains ("Map"))
			{
				//The player gains a map.
				Player.inventory.Add (new GameItem ("Map", "Map"));
				//Map icon on the UI is set to visible.
				MainController.MapButtonVisibility ();
				//Triggers dialogue with specific NPC.
				GameObject.Find (this.name).GetComponent<DialogueTrigger> ().TriggerDialogue ();
			}
		}
	}
	//When leaving the trigger area.
	void OnTriggerExit(Collider col)
	{	
		if (col.name.Equals ("JJ_Jackson"))
		{
			clickable = false;
		}
	}
}


