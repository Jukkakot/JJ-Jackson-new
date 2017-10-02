using System;
using UnityEngine;
using System.Collections;

public class Teleport: MonoBehaviour
{
	public Transform destination;
	public string tagList = "|Player|";

	void start(){}

	void update(){}

	void OnTriggerEnter(Collider col)
	{
		if (tagList.Contains (string.Format ("|{0}|", col.tag)))
		{
			col.transform.position = destination.transform.position;
		}
	}
}