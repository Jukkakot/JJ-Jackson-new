using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
	Button bInventory, invExit, ImageButton0,ImageButton1,ImageButton2,ImageButton3,ImageButton4,ImageButton5,inventoryClear;
	Button mapOpenButton, mapExitButton;
	Rigidbody player, NPC_City, NPC_SaloonBartender, NPC_SaloonInjun,NPC_InjunBoss, NPC_Shaman, NPC_VP;
	GameObject invVis, mapVis;
	public static GameObject mapButtonVis;
	Text currentItem;
	public static bool inventoryOpen = false;
	public static bool mapOpen = false;
	//Player JJ = new Player(); Cant use this at the moument, have to make player methods and variables public.

	void Start ()
	{
		//Inventory objects
		ImageButton0 = GameObject.Find ("ImageButton0").GetComponent<Button> ();
		ImageButton1 = GameObject.Find ("ImageButton1").GetComponent<Button> ();
		ImageButton2 = GameObject.Find ("ImageButton2").GetComponent<Button> ();
		ImageButton3 = GameObject.Find ("ImageButton3").GetComponent<Button> ();
		ImageButton4 = GameObject.Find ("ImageButton4").GetComponent<Button> ();
		ImageButton5 = GameObject.Find ("ImageButton5").GetComponent<Button> ();
		invVis = GameObject.Find ("InventoryScreen");
		bInventory = GameObject.Find ("ButtonInventory").GetComponent<Button> ();
		invExit = GameObject.Find ("InventoryExit").GetComponent<Button> ();
		inventoryClear = GameObject.Find ("InventoryClear").GetComponent<Button> ();

		//Map objects
		mapOpenButton = GameObject.Find ("MapOpenButton").GetComponent<Button> ();
		mapExitButton = GameObject.Find ("MapExit").GetComponent<Button> ();
		mapVis = GameObject.Find ("MapScreen");
		mapButtonVis = GameObject.Find ("MapOpenButton");
		//Misc objects
		currentItem = GameObject.Find ("CurrentItem").GetComponent<Text> ();
		player = GameObject.Find ("JJ_Jackson").GetComponent<Rigidbody>();

		invVis.SetActive (false);
		mapVis.SetActive (false);
		mapButtonVis.SetActive (false);

		inventoryClear.onClick.AddListener (clearCurrentItem);

		bInventory.onClick.AddListener (inventoryVisibility);
		invExit.onClick.AddListener (inventoryVisibility);

		mapOpenButton.onClick.AddListener (mapVisibility);
		mapExitButton.onClick.AddListener (mapVisibility);

		ImageButton0.onClick.AddListener (() => invButton(ImageButton0.name));
		ImageButton1.onClick.AddListener (() => invButton(ImageButton1.name));
		ImageButton2.onClick.AddListener (() => invButton(ImageButton2.name));
		ImageButton3.onClick.AddListener (() => invButton(ImageButton3.name));
		ImageButton4.onClick.AddListener (() => invButton(ImageButton4.name));
		ImageButton5.onClick.AddListener (() => invButton(ImageButton5.name));
		/*NPC_City = GameObject.Find ("NPCCity").GetComponent<Rigidbody> ();
		NPC_SaloonBartender = GameObject.Find ("NPCSaloonBartender").GetComponent<Rigidbody> ();
		NPC_SaloonInjun = GameObject.Find ("NPCSaloonInjun").GetComponent<Rigidbody> ();
		NPC_InjunBoss = GameObject.Find ("NPCInjunBoss").GetComponent<Rigidbody> ();
		NPC_Shaman = GameObject.Find ("NPCShaman").GetComponent<Rigidbody> ();
		NPC_VP = GameObject.Find ("NPCVP").GetComponent<Rigidbody> ();
	*/

	}
		
	public static void MapButtonVisibility () {
		mapButtonVis.SetActive (true);
	}

	void clearCurrentItem () {
		if (Player.hasActiveItem) {
			Player.activeItem = null;
			Player.hasActiveItem = false;
		}
		invVis.SetActive (false);
		inventoryOpen = false;
	}

	void invButton (string name) {
		if (Player.hasActiveItem)
		{
			string tempActiveItem = Player.activeItem.GetName (); //Saves current active item tempprarely
			Player.updateActiveItem (name);
			if (!tempActiveItem.Equals(Player.activeItem.GetName())) //Inventory is closed if players active item was changed.
			{
				invVis.SetActive (false);
				inventoryOpen = false;
			}
		}
		else {
			Player.updateActiveItem (name);
			invVis.SetActive (false);
			inventoryOpen = false;
		}
	}
	void mapVisibility () {
		if (mapOpen) {
			mapVis.SetActive (false);
			mapOpen = false;
		}
		else {
			mapVis.SetActive(true);
			mapOpen = true;
			Player.updateMapButtons ();
		}
	}

	void inventoryVisibility () {
		if (inventoryOpen) {
			invVis.SetActive (false);
			inventoryOpen = false;
		}
		else {
			invVis.SetActive(true);
			inventoryOpen = true;
			Player.updateInventory ();
		}
	}

	void Update ()
	{
		player.transform.Translate (0, 0, ((FindObjectOfType <VirtualJoystick> ().inputDirection.z)*Player.playerSpeed));
		player.transform.Rotate (0, ((FindObjectOfType <VirtualJoystick> ().inputDirection.x)*Player.rotationSpeed), 0);

		Vector3 lookDirection = new Vector3(player.position.x, 0 , player.position.z);
		/*
		NPC_City.transform.LookAt (lookDirection);
		NPC_InjunBoss.transform.LookAt (lookDirection);
		NPC_SaloonBartender.transform.LookAt (lookDirection);
		NPC_SaloonInjun.transform.LookAt (lookDirection);
		NPC_Shaman.transform.LookAt (lookDirection);
		NPC_VP.transform.LookAt (lookDirection);
		*/
		
		//Updates the currentItem text
		if (Player.hasActiveItem) {
			currentItem.text = "Current item: " + Player.getActiveItem ().GetName ();
		} else {
			currentItem.text = "Current item:";
		}
	}
}
