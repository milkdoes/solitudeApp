using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	private void Awake() {
		Messenger.AddListener (GameEvent.DOOR_MOVED, OnDoorMoved);
	}

	private void OnDestroy() {
		Messenger.RemoveListener (GameEvent.DOOR_MOVED, OnDoorMoved);
	}

	/// <summary>
	/// Restart current scene when door has moved.
	/// </summary>
	private void OnDoorMoved() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
