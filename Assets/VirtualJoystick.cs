using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image backgroundImage;
	private Image joystickImage;
	public Vector3 inputDirection{ get; set; }
	Animator anim;

	public void Start(){

		anim = GameObject.Find ("JJ_Jackson").GetComponent<Animator> ();
		backgroundImage = GetComponent<Image> ();
		joystickImage = transform.GetChild(0).GetComponent<Image>();
		inputDirection = Vector3.zero;
	}
	//calculating joystics placement on top of background picture while being its on drag
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle
			(backgroundImage.rectTransform,
				ped.position,
				ped.pressEventCamera,
				out pos))
		{
			//using triangle to calculate the correct placement in x,y coordinates
			pos.x = (pos.x / backgroundImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / backgroundImage.rectTransform.sizeDelta.y);

			//(condition) ? [true] : [false]
			float x = (backgroundImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (backgroundImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			//inputting the coordinates in 3d vector to move the character
			inputDirection = new Vector3 (x, 0, y);
			inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;

			joystickImage.rectTransform.anchoredPosition =
				new Vector3 (inputDirection.x * (backgroundImage.rectTransform.sizeDelta.x / 3),
					inputDirection.z * (backgroundImage.rectTransform.sizeDelta.y / 3));
		}
		//setting animation speed equal to movement speed
		anim.SetFloat ("walkSpeed", (inputDirection.z));
		//Debug.Log (inputDirection);
		//Debug.Log ("Drag");
	}
	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
		anim.SetBool ("pointerDown" , true);
		//Debug.Log ("down");
	}
	public virtual void OnPointerUp(PointerEventData ped)
	{
		//setting everything to zero so the movement and the joystick stops as joystick is released.
		inputDirection = Vector3.zero;
		joystickImage.rectTransform.anchoredPosition = Vector3.zero;
		anim.SetBool ("pointerDown" , false);
		//Debug.Log ("up");

	}	
}