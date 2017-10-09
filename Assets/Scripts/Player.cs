using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
	public static List<GameItem> inventory = new List<GameItem>();
	public static List<string> stringInventory = new List<string> (); //List of items in inventory in string format

	public static float playerSpeed = 0.30f;
	public static float rotationSpeed = 3f;

	public static GameItem activeItem;
	public static bool hasActiveItem = false;
	public static bool hasMap = false;

	public static void updateStringInventory () { //updates players string inventory
		stringInventory.Clear();
		foreach (GameItem item in Player.inventory) {
			stringInventory.Add (item.GetName ());
		}
	}
	public static void updateInventory () {
		//resets the stringInventory list
		updateStringInventory();
		//Sets every inventory image to default picture
		for (int index = 0; index <= 5; index++) {
			GameObject.Find ("ItemImage" + index).GetComponent<RawImage> ().texture =
				(Texture)Resources.Load ("DefaultItemImage", typeof(Texture));
		}
		//changes the image of itemimage if needed
		int count = 0;
		foreach (GameItem item in inventory) {
			GameObject.Find ("ItemImage" + count).GetComponent<RawImage> ().texture = 
				(Texture)Resources.Load (item.GetName(), typeof(Texture));
			count++;
		}
	}
	public static void updateActiveItem (string name) {
		int ButtonNumber = (int)char.GetNumericValue(name[11]); //The number of the button pressed

		if (inventory.Count >= ButtonNumber + 1) {	//Inventory count is always one higher than 
													//the buttonNumber of the last item in inventory
													//bevcause buttonNumber is index.
			Player.activeItem = Player.inventory [ButtonNumber];
			Player.hasActiveItem = true;
		}
	}

	public static GameItem getActiveItem () {
		if (Player.hasActiveItem) {
			return activeItem;
		} else {
			return activeItem;
		}
	}

	public static void updateMapButtons ( ) { //updates the picture in map screen
		updateStringInventory ();
		if (Player.stringInventory.Contains ("Map") || Player.stringInventory.Contains ("MapToVP")) {
			if (Player.stringInventory.Contains ("Map")) {
				GameObject.Find ("MapImage0").GetComponent<RawImage> ().texture =
				(Texture)Resources.Load ("Map", typeof(Texture));
			}
			if (Player.stringInventory.Contains ("MapToVP")) {
				GameObject.Find ("MapImage0").GetComponent<RawImage> ().texture =
				(Texture)Resources.Load ("MapToVP", typeof(Texture));
			}
		}else {
			GameObject.Find ("MapImage0").GetComponent<RawImage> ().texture =
				(Texture)Resources.Load ("DefaultMapImage", typeof(Texture));
		}	
}
}
