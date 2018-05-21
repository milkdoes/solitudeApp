using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
	// Define seconds needed in bed to win.
	private const float SECONDS_TO_WIN = 30.0f;
	// Define time left to win.
	private float timeLeftToWin = 0.0f;
	// Keep track if player is in bed.
	private bool inBed = false;

	private void Awake() {
		// Define time left to win.
		timeLeftToWin = SECONDS_TO_WIN;

		// Define event listeners.
		Messenger.AddListener (GameEvent.DOOR_MOVED, OnDoorMoved);
		Messenger.AddListener (GameEvent.IN_BED, InBed);
		Messenger.AddListener (GameEvent.PLAYER_MOVED, PlayerMoved);
	}

	void Update() {
		// Reduce time left to win if player is in bed.
		if (timeLeftToWin != null && inBed == true) {
			timeLeftToWin -= Time.deltaTime;
			UnityEngine.Debug.Log ("Time left: " + timeLeftToWin);
		}

		if (timeLeftToWin <= 0)
			ActivateGameOver ();
	}

	private void OnDestroy() {
		Messenger.RemoveListener (GameEvent.DOOR_MOVED, OnDoorMoved);
	}

	/// <summary>
	/// Restart current scene when door has moved.
	/// </summary>
	private void OnDoorMoved() {
		ActivateGameOver ();
	}

	private void InBed() {
		inBed = true;
	}

	private void PlayerMoved() {
		timeLeftToWin = SECONDS_TO_WIN;
		inBed = false;
	}

	private void ActivateGameOver() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
