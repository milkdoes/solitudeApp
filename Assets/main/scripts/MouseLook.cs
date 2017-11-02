using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			// Horizontal rotation here.
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor
					, 0);
		} else if (axes == RotationAxes.MouseY) {
			// Vertical rotation here.
		} else {
			// Both horizontal and vertical rotation.
		}
		
	}
}
