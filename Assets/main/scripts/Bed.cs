using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour {
	// GENERAL SETTINGS.
	private string OBJECT_TAG = "Bed";

	// Use this for initialization
	void Start () {
		gameObject.tag = OBJECT_TAG;
		OnDrawGizmosSelected ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmosSelected () {
		ReTag(transform, transform.tag);
	}

	void ReTag (Transform _transform, string tag) {
		foreach(Transform child in _transform) {
			child.gameObject.tag = tag;
			ReTag(child, tag);
		}
	}
}
