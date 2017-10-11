using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tumbleweed : MonoBehaviour {
	public Transform[] patrolPoints;
	public float movementSpeed;
	private int currentPoint;

	// Use this for initialization
	void Start () {
		transform.position = patrolPoints [0].position;
		currentPoint = 0;
	}

	// Update is called once per frame
	void Update ()
	{

		if(transform.position.x == patrolPoints [currentPoint].position.x)
		{
			currentPoint++;
		}
		if (currentPoint >= patrolPoints.Length) {
			currentPoint = 0;
		}
		transform.position = Vector3.MoveTowards (transform.position, patrolPoints [currentPoint].position, movementSpeed * Time.deltaTime);
	}

}
