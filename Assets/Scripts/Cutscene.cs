using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
	public Texture[] frames;	//Simple array of textures
	public float secondsPerFrame;	//How many seconds reserved for each frame

	public int currentScene;

	private int frame = 0;
	private float nextFrame = 0f;
	void Start ()//Setting everything to 0, just in case.
	{
		Screen.orientation = ScreenOrientation.Landscape;
		frame = 0;
		nextFrame = 0f;

	}
	void OnGUI()
	{		
		//Checks whether the current frame is the last frame or not
		if (this.frame < this.frames.Length)
		{
			if ( Time.timeSinceLevelLoad >= nextFrame)
			{
				this.frame++;
				nextFrame += framesPerSecond;
			}
			//Draws the textures in the array to the canvas
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), this.frames [this.frame - 1]);
		}
		else 
		{	//If current scene is not the ending
			if (currentScene < 3) 
			{
				SceneManager.LoadScene (currentScene + 1);
			}
			else
			{		
				Application.Quit ();
			}
		}
		
	}
}


