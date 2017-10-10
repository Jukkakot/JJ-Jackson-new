using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
	public Texture[] frames;
	public int framesPerSecond = 3;

	public int currentScene;

	private int frame = 0;
	private int nextFrame = 0;
	void Start () {
		Screen.orientation = ScreenOrientation.Landscape;
	}
	void OnGUI()
	{		
		if (this.frame < this.frames.Length) 
		{
			if (Time.time >= nextFrame)
			{
				this.frame++;
				nextFrame += framesPerSecond;
			}
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), this.frames [this.frame - 1]);
		}
		else 
		{	
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


