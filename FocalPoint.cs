/*
        Jerry Heylmun: The Watchers 2015
        File:    FocalPoint.cs
        Purpose: Adjust the focus distance of the camera based on the closest object in front of the player.

        explanation: 
            Using raycasts, fire a cone in front of the player. Then, slide the focal point to the distance of the closest object.
            This gives objects the feeling of "Coming in to focus". For example, an enemy at the edge of your vision is blurry.
*/

using UnityEngine;
using System.Collections;

public class FocalPoint : MonoBehaviour {
	[SerializeField]
	float maxFocusDistance = 10.0f;
	[SerializeField]
	float focusInSpeed = 10.0f;
	[SerializeField]
	float focusOutSpeed = 10.0f;
	Transform PlayerCamera;
	float currentFocus;
	float lastFocus;
	RaycastHit hit;
	Vector3 slightLeft = new Vector3(-0.15f,0f,1f);
	Vector3 slightRight = new Vector3(0.15f,0f,1f);
	// Use this for initialization
	void Start () {
		PlayerCamera = transform.parent;
		currentFocus = maxFocusDistance;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Physics.Raycast (PlayerCamera.position, PlayerCamera.TransformDirection (Vector3.forward), out hit, maxFocusDistance)) {
			//Debug.Log ("MainRay hit.");
			currentFocus = hit.distance;
		} else {
			currentFocus = maxFocusDistance;
		}
		if (Physics.Raycast (PlayerCamera.TransformPoint (-0.1f,0,0), PlayerCamera.TransformDirection (slightLeft), out hit, maxFocusDistance)) {
			//Debug.Log ("LeftRay hit.");
			if(hit.distance < currentFocus){
				currentFocus = hit.distance;
			}
		}
		if (Physics.Raycast (PlayerCamera.TransformPoint (0.1f,0,0), PlayerCamera.TransformDirection (slightRight), out hit, maxFocusDistance)) {
			//Debug.Log ("RightRay hit.");
			if(hit.distance < currentFocus){
				currentFocus = hit.distance;
			}
		}
		float step= 1.0f;
		if (lastFocus < currentFocus) { // Focus Out
			step = focusOutSpeed * Time.deltaTime;
		} else { // Focus In
			step = focusInSpeed * Time.deltaTime;
		}
		transform.position = Vector3.MoveTowards(transform.position,PlayerCamera.TransformPoint (0,0,currentFocus), step);
	}
}
