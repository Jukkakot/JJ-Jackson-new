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
	 	objectDictionary.Add ("Revolver","broomStick");
		objectDictionary.Add ("Celldoor", "Revolver");
		objectDictionary.Add ("NPCSaloonBartender", "Coin");
		objectDictionary.Add ("NPCSaloonInjun", "ShotClass");
		objectDictionary.Add ("NPCInjunBoss", "Alcohol");
		objectDictionary.Add ("Shaman", "Mushroom");
		objectDictionary.Add ("NPCVP", "Revolver");
	}


	public void OnTriggerEnter(Collider col)
	{
		Debug.Log ("You're close to "+this.name);
			clickable = true;
		
	}

	public void OnMouseDown()
	{
		if (clickable && Player.hasActiveItem && !MainController.inventoryOpen && !MainController.mapOpen) {
			currentActiveItem = Player.activeItem.GetName ();
			doAction (this.name);
		} else {
			//Nothing happens when player isnt next to the object or when player dont have any active item or when invetory screen is open.
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
		case "Revolver": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				//Add code here, what to do when default gameItem is used on gameObject
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);
				GameObject.Find (currentObject).SetActive (false);
				Player.inventory.Add (new GameItem(currentObject,currentObject));
				//------------------------------------------------------------------------
				Player.inventory.RemoveAt (index);
				Player.hasActiveItem = false;
				Player.activeItem = null;
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "Celldoor": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);

				//Add code here, what to do when default gameItem is used on gameObject
				//GameObject.Find (currentObject).GetComponent<BoxCollider> ().enabled = false;
				GameObject.Find (currentObject).SetActive(false);
				//--------------------------------------------------------------------
				Player.inventory.RemoveAt (index);
				Player.hasActiveItem = false;
				Player.activeItem = null;
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "NPCCity": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);

				//Add code here, what to do when default gameItem is used on gameObject
				GameObject.Find (currentObject).GetComponent<DialogueTrigger> ().TriggerDialogue ();
				//--------------------------------------------------------------------
				Player.inventory.RemoveAt (index);
				Player.hasActiveItem = false;
				Player.activeItem = null;
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "NPCSaloonBartender": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);

				//Add code here, what to do when default gameItem is used on gameObject
				Player.inventory.Add(new GameItem("ShotClass","ShotClass"));
				FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
				//--------------------------------------------------------------------
				Player.inventory.RemoveAt (index);
				Player.hasActiveItem = false;
				Player.activeItem = null;
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "NPCSaloonInjun": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);

				//Add code here, what to do when default gameItem is used on gameObject
				Player.inventory.Add(new GameItem("Alcohol","Alcohol"));
				FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
				//--------------------------------------------------------------------
				Player.inventory.RemoveAt (index);
				Player.hasActiveItem = false;
				Player.activeItem = null;
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "NPCInjunBoss": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);

				//Add code here, what to do when default gameItem is used on gameObject
				Player.inventory.Add(new GameItem("MapToMushroom","MapToMushroom"));
				FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
				//--------------------------------------------------------------------
				Player.inventory.RemoveAt (index);
				Player.hasActiveItem = false;
				Player.activeItem = null;
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "NPCShaman": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);

				//Add code here, what to do when default gameItem is used on gameObject
				Player.inventory.Add(new GameItem("MapToVP","MapToVP"));
				FindObjectOfType<DialogueTrigger> ().TriggerDialogue ();
				//--------------------------------------------------------------------
				Player.inventory.RemoveAt (index);
				Player.hasActiveItem = false;
				Player.activeItem = null;
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		case "NPCVP": 
			if (objectDictionary[currentObject] == currentActiveItem) {
				Debug.Log ("OIKEA KOMBINAATIO! "+currentObject + " + "+currentActiveItem);

				//Add code here, what to do when default gameItem is used on gameObject
				GameObject.Find("NPCVP").GetComponent<Transform> ().Rotate(0,-90f,0);
				//--------------------------------------------------------------------
				Player.inventory.RemoveAt (index);
				Player.hasActiveItem = false;
				Player.activeItem = null;
			} else {
				//Add code here, what to do when any other gameItem was used to the object other than the default gameItem
				Debug.Log (currentActiveItem + " käytettiin objektiin: " + currentObject+ " mutta ei tehty mitään");
			}
			break;
		default:
			Debug.Log ("Active item: "+currentActiveItem+"\ncurrent object: "+currentObject + " default lause");
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
