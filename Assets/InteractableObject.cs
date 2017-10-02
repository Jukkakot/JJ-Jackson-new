using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
	bool clickable=false;
//	public string tagList = "|Stone|Rope|Twig|";

	Dictionary<string,string> objectDictionary = new Dictionary<string,string> ();
	//Dictionary <gameObject, gameItem>
	string currentActiveItem;

		
	public InteractableObject (){
		//Add "default" gameItem for each gameObject, you can have same gameItem for multiple gameObjects
	 	objectDictionary.Add ("Door","Rope");
		objectDictionary.Add ("Door2", "Twig");
		objectDictionary.Add ("Door3","Stone");
	}


	public void OnTriggerEnter(Collider col)
	{
		Debug.Log ("You're close to "+this.name);
			clickable = true;
		
	}

	public void OnMouseDown()
	{
		if (clickable && Player.hasActiveItem && MainController.inventoryOpen == false ) {
			currentActiveItem = Player.activeItem.GetName ();
			doAction (this.name);
		} else {
			Debug.Log ("Ei ollut aktiivista tavaraa tai ei ollu oikea tavara");
		}
	}

	void OnTriggerExit(Collider col)
	{
		Debug.Log ("You left "+this.name);
			clickable = false;
	}

		public void doAction ( string currentObject ) {
		
		int index = Player.stringInventory.IndexOf (currentActiveItem); //index of currently active item in players inventory
			
		switch (currentObject) {
		case "Door": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				//Add code here, what to do when default gameItem is used on gameObject
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);
				GameObject.Find (currentObject).SetActive (false);
				Player.inventory.RemoveAt (index);
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "Door2": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				//Add code here, what to do when default gameItem is used on gameObject
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);
				GameObject.Find (currentObject).SetActive (false);
				Player.inventory.RemoveAt (index);
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "Door3": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				//Add code here, what to do when default gameItem is used on gameObject
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);
				GameObject.Find (currentObject).SetActive (false);
				Player.inventory.RemoveAt (index);
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		default:
			Debug.Log (currentActiveItem + " default lause");
			break;
		}


	}
/*	public static void removeItemFromInventory (GameItem item) {
		//Removes given GameItem from the inventory list and from the graphic inventory in game

		List<string> newList = new List<string> ();
		foreach (GameItem currentItem in Player.inventory) {
			newList.Add (currentItem.GetName ());
		}
		int count = newList.IndexOf (item.GetName ());
		Debug.Log ("count " + count);

		GameObject.Find ("ItemImage" + count).GetComponent<RawImage> ().texture = 
			(Texture)Resources.Load ("DefaultItemImage", typeof(Texture));
		
		Player.inventory.RemoveAt (count);
	}*/

}
