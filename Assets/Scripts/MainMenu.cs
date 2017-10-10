using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public bool isStart, isQuit;

	void Start()
	{
		Screen.orientation = ScreenOrientation.Landscape;
		GetComponent<Renderer> ().material.color = Color.white;
	}


	void OnMouseEnter()
	{
		GetComponent<Renderer> ().material.color = Color.black;	
	}

	void OnMouseExit()
	{
		GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseUp()
	{
		if (isQuit)
		{
			Debug.Log ("Quitting the game...");
			Application.Quit ();
		}

		if (isStart)
			SceneManager.LoadScene (1);
	}

}
