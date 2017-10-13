using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
	//Name for the NPC.
	public string name;

	//Creating the text area for Unity, and an array of sentences.
	[TextArea(3, 10)]
	public string[] sentences;

}
