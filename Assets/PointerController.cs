using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pressed;

	public void OnPointerUp(PointerEventData eventData)
	{
		pressed = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		//Debug.Log ("Pressed a button");
		//Debug.Log (eventData);
		pressed = true;
	}

	public bool GetPressed(){return pressed;}
}
