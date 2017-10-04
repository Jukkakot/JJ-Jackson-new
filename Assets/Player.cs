using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
	//string playerName = "J.J. Jackson";
	public static List<GameItem> inventory = new List<GameItem>();
	public static List<string> stringInventory = new List<string> ();
	//List of items in inventory in string format
	Vector3 playerPosition;
	public static float playerSpeed = 0.15f;
	public static float rotationSpeed = 1.5f;

	public static string tagList = "|Player|";
	public static GameItem activeItem;
	public static bool hasActiveItem = false;
	public Player ()
	{}

	public void AddItem(GameItem item)
	{
		Player.inventory.Add (item);
	}

	public float GetSpeed()
	{
		return playerSpeed;
	}
	public static void updateStringInventory () {
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
		//Debug.Log ("Button Number: " + ButtonNumber);
		if (inventory.Count >= ButtonNumber + 1) {	//Inventory count is always one higher than 
													//the buttonNumber of the last item in inventory
													//bevcause buttonNumber is index.
			Player.activeItem = Player.inventory [ButtonNumber];
			Player.hasActiveItem = true;
			Debug.Log ("Aktiivinen item on nyt " + Player.activeItem.GetName ());
		}
	}

	public static GameItem getActiveItem () {
		if (Player.hasActiveItem) {
			return activeItem;
		} else {
			Debug.Log ("Aktiivista itemiä ei ollut");
			return activeItem;
		}
	}
	/*void OnTriggerEnter(Collider col)
	{
		if (tagList.Contains (string.Format ("|{0}|", col.tag)))
		{
			Debug.Log (col.gameObject.name+ " poimittu");
			AddItem (new GameItem (col.gameObject.name));
			col.gameObject.active = false;
		}
	}
	*/
}
