using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
	public Texture[] frames;
	public float framesPerSecond;

	public int currentScene;

	private int frame = 0;
	private float nextFrame = 0f;
	void Start () {
		Screen.orientation = ScreenOrientation.Landscape;
		frame = 0;
		nextFrame = 0f;

	}
	void OnGUI()
	{		
		
		if (this.frame < this.frames.Length) 
		{
			if ( Time.timeSinceLevelLoad >= nextFrame)
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


