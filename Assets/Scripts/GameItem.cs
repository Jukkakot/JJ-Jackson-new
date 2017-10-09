using System;
using UnityEngine;

public class GameItem: MonoBehaviour
{
	private string itemName;
	private string imageName;
	public GameItem (string itemName,string imageName)
	{
		this.itemName = itemName;
		this.imageName = imageName;
	}

	public string GetName(){
		return this.itemName;
	}
}


