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
	private int nextFrame;

	void OnGUI()
	{
	if (frame < frames.Length)
		{
		if (Time.time >= nextFrame)
			{
				frame++;
				nextFrame += framesPerSecond;
			}
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), frames [frame-1]);
		}
		if(frame==frames.Length)
			SceneManager.LoadScene (currentScene + 1);
	}

}
