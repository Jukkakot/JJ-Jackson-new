using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
<<<<<<< HEAD
	Button bInventory, invExit, ImageButton0,ImageButton1,ImageButton2,ImageButton3,ImageButton4,ImageButton5;
	Rigidbody player, npc, indianChief;
	GameObject invVis;
=======
	Button bInventory, invExit, ImageButton0,ImageButton1,ImageButton2,ImageButton3,ImageButton4,ImageButton5, bPause, pauseExit, quitGame;
	Rigidbody player, npc;
	GameObject invVis, pauseVis;
>>>>>>> d94350c2838e0a6d4c985e09e3a3a2b5738ec45b
	Text currentItem;
	public static bool inventoryOpen = false;
	public static bool pauseOpen = false;
	//Player JJ = new Player(); Cant use this at the moument, have to make player methods and variables public.

	void Start ()
	{
		ImageButton0 = GameObject.Find ("ImageButton0").GetComponent<Button> ();
		ImageButton1 = GameObject.Find ("ImageButton1").GetComponent<Button> ();
		ImageButton2 = GameObject.Find ("ImageButton2").GetComponent<Button> ();
		ImageButton3 = GameObject.Find ("ImageButton3").GetComponent<Button> ();
		ImageButton4 = GameObject.Find ("ImageButton4").GetComponent<Button> ();
		ImageButton5 = GameObject.Find ("ImageButton5").GetComponent<Button> ();

		currentItem = GameObject.Find ("CurrentItem").GetComponent<Text> ();
		bInventory = GameObject.Find ("ButtonInventory").GetComponent<Button> ();
		bPause = GameObject.Find ("ButtonPause").GetComponent<Button> ();
		player = GameObject.Find ("JJ_Jackson").GetComponent<Rigidbody>();
		invVis = GameObject.Find ("InventoryScreen");
		pauseVis = GameObject.Find ("PauseMenu");
		invExit = GameObject.Find ("InventoryExit").GetComponent<Button> ();
		quitGame = GameObject.Find ("Quit Game").GetComponent<Button> ();
		pauseExit = GameObject.Find ("PauseExit").GetComponent<Button> ();
		npc = GameObject.Find ("NPC").GetComponent<Rigidbody> ();
		indianChief = GameObject.Find ("IndianChief").GetComponent<Rigidbody> ();
		invVis.SetActive (false);
		pauseVis.SetActive (false);

		currentItem = GameObject.Find ("CurrentItem").GetComponent<Text> ();

		bInventory.onClick.AddListener (inventoryVisibility);
		bPause.onClick.AddListener (pauseVisibility);
		invExit.onClick.AddListener (inventoryVisibility);
		pauseExit.onClick.AddListener (pauseVisibility);
		quitGame.onClick.AddListener (Application.Quit);
		ImageButton0.onClick.AddListener (() => invButton(ImageButton0.name));
		ImageButton1.onClick.AddListener (() => invButton(ImageButton1.name));
		ImageButton2.onClick.AddListener (() => invButton(ImageButton2.name));
		ImageButton3.onClick.AddListener (() => invButton(ImageButton3.name));
		ImageButton4.onClick.AddListener (() => invButton(ImageButton4.name));
		ImageButton5.onClick.AddListener (() => invButton(ImageButton5.name));


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
	void pauseVisibility () {
		if (pauseOpen == true) {
			pauseVis.SetActive (false);
			pauseOpen = false;
		}
		else {
			pauseVis.SetActive(true);
			pauseOpen = true;
			}
	}

	void Update ()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			SceneManager.LoadScene (2);
		}
		
		player.transform.Translate (0, 0, ((FindObjectOfType <VirtualJoystick> ().inputDirection.z)*Player.playerSpeed));
		player.transform.Rotate (0, ((FindObjectOfType <VirtualJoystick> ().inputDirection.x)*Player.rotationSpeed), 0);

		Vector3 lookDirection = new Vector3(player.position.x, 0 , player.position.z);

		npc.transform.LookAt (lookDirection);
		indianChief.transform.LookAt (lookDirection);
		//Updates the currentItem text
		if (Player.hasActiveItem) {
			currentItem.text = "Current item: " + Player.getActiveItem ().GetName ();
		} else {
			currentItem.text = "Current item:";
		}
	}
}
