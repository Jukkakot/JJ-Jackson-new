/*using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Objectes : MonoBehaviour {

	Dictionary<string,string> objectDictionary = new Dictionary<string,string> ();
	List<string> stringInventory = new List<string> ();

	// Dictionary<gameObject, gameItem>
	public Objectes () {
		objectDictionary.Add ("Door", "Rope");
		objectDictionary.Add ("Door2", "Twig");
		objectDictionary.Add ("Door3", "Stone");

		foreach (GameItem currentItem in Player.inventory) {
			stringInventory.Add (currentItem.GetName ());
		}
	}
	public void doAction ( string currentObject ) {
		

		string currentActiveItem = Player.activeItem.GetName ();
		int index = stringInventory.IndexOf(currentActiveItem);
		switch (currentObject) {
		case "Door": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);
				GameObject.Find (currentObject).GetComponent<SpriteRenderer> ().enabled = false;
				Debug.Log (index);
				Player.inventory.RemoveAt (index);
			} else {
				Debug.Log (currentActiveItem + " käytettiin " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "Door2": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);
				GameObject.Find (currentObject).GetComponent<SpriteRenderer> ().enabled = false;
				Player.inventory.RemoveAt (index);
			} else {
				Debug.Log (currentActiveItem + " käytettiin " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "Door3": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);
				GameObject.Find (currentObject).GetComponent<SpriteRenderer> ().enabled = false;
				Player.inventory.RemoveAt (index);
			} else {
				Debug.Log (currentActiveItem + " käytettiin " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		default:
			Debug.Log (currentActiveItem + " default lause");
			break;
		}


	}
	public static void removeItemFromInventory (GameItem item) {
		//Removes given GameItem from the inventory list and from the graphic inventory in game

		List<string> newList = new List<string> ();
		foreach (GameItem currentItem in Player.inventory) {
			newList.Add (currentItem.GetName ());
		}
		int count = newList.IndexOf (item.GetName ());
		GameObject.Find ("ItemImage" + count).GetComponent<RawImage> ().texture = 
			(Texture)Resources.Load ("DefaultItemImage", typeof(Texture));
		Player.inventory.RemoveAt (count);
	}
}
*/
