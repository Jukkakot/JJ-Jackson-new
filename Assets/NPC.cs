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
<<<<<<< HEAD
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
=======
		if (!clickable)
		{
			return;
		}

		Debug.Log ("You clicked me");
		FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
>>>>>>> 42b5aafa476634553cb064bb670d7ad98b796415
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name == "JJ_Jackson")
		{
			clickable = false;
		}
	}
}


