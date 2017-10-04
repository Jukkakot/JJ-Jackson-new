﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
	Button bInventory, invExit, ImageButton0,ImageButton1,ImageButton2,ImageButton3,ImageButton4,ImageButton5;
	Rigidbody player, NPC_City, NPC_SaloonBartender, NPC_SaloonInjun,NPC_InjunBoss, NPC_Shaman, NPC_VP;
	GameObject invVis;
	public static bool inventoryOpen = false;
	//Player JJ = new Player(); Cant use this at the moument, have to make player methods and variables public.

	void Start ()
	{
		ImageButton0 = GameObject.Find ("ImageButton0").GetComponent<Button> ();
		ImageButton1 = GameObject.Find ("ImageButton1").GetComponent<Button> ();
		ImageButton2 = GameObject.Find ("ImageButton2").GetComponent<Button> ();
		ImageButton3 = GameObject.Find ("ImageButton3").GetComponent<Button> ();
		ImageButton4 = GameObject.Find ("ImageButton4").GetComponent<Button> ();
		ImageButton5 = GameObject.Find ("ImageButton5").GetComponent<Button> ();

		bInventory = GameObject.Find ("ButtonInventory").GetComponent<Button> ();
		player = GameObject.Find ("JJ_Jackson").GetComponent<Rigidbody>();
		invVis = GameObject.Find ("InventoryScreen");
		invExit = GameObject.Find ("InventoryExit").GetComponent<Button> ();
<<<<<<< HEAD

=======
		npc = GameObject.Find ("NPC").GetComponent<Rigidbody> ();
>>>>>>> 42b5aafa476634553cb064bb670d7ad98b796415
		invVis.SetActive (false);

		bInventory.onClick.AddListener (inventoryVisibility);
		invExit.onClick.AddListener (inventoryVisibility);
		ImageButton0.onClick.AddListener (() => invButton(ImageButton0.name));
		ImageButton1.onClick.AddListener (() => invButton(ImageButton1.name));
		ImageButton2.onClick.AddListener (() => invButton(ImageButton2.name));
		ImageButton3.onClick.AddListener (() => invButton(ImageButton3.name));
		ImageButton4.onClick.AddListener (() => invButton(ImageButton4.name));
		ImageButton5.onClick.AddListener (() => invButton(ImageButton5.name));

		NPC_City = GameObject.Find ("NPCCity").GetComponent<Rigidbody> ();
		NPC_SaloonBartender = GameObject.Find ("NPCSaloonBartender").GetComponent<Rigidbody> ();
		NPC_SaloonInjun = GameObject.Find ("NPCSaloonInjun").GetComponent<Rigidbody> ();
		NPC_InjunBoss = GameObject.Find ("NPCInjunBoss").GetComponent<Rigidbody> ();
		NPC_Shaman = GameObject.Find ("NPCShaman").GetComponent<Rigidbody> ();
		NPC_VP = GameObject.Find ("NPCVP").GetComponent<Rigidbody> ();


	}
	void invButton (string name) {
		Player.updateActiveItem (name);
	}
	void inventoryVisibility () {
		if (inventoryOpen == true) {
			invVis.SetActive (false);
			inventoryOpen = false;
		}
		else {
			invVis.SetActive(true);
			inventoryOpen = true;
			Player.updateInventory ();
		}
	}
	// Update is called once per frame
	void Update ()
	{
		player.transform.Translate (0, 0, ((FindObjectOfType <VirtualJoystick> ().inputDirection.z)*Player.playerSpeed));
		player.transform.Rotate (0, ((FindObjectOfType <VirtualJoystick> ().inputDirection.x)*Player.rotationSpeed), 0);

		Vector3 lookDirection = new Vector3(player.position.x, 0 , player.position.z);

<<<<<<< HEAD
		NPC_City.transform.LookAt (lookDirection);
		NPC_InjunBoss.transform.LookAt (lookDirection);
		NPC_SaloonBartender.transform.LookAt (lookDirection);
		NPC_SaloonInjun.transform.LookAt (lookDirection);
		NPC_Shaman.transform.LookAt (lookDirection);
		NPC_VP.transform.LookAt (lookDirection);
		
		//Updates the currentItem text
		if (Player.hasActiveItem) {
			currentItem.text = "Current item: " + Player.getActiveItem ().GetName ();
		} else {
			currentItem.text = "Current item:";
		}
=======
		npc.transform.LookAt (lookDirection);
>>>>>>> 42b5aafa476634553cb064bb670d7ad98b796415
	}
}
