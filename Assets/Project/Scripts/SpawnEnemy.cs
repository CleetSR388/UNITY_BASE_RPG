using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject enemyEncounterPrefab;

	private bool spawning = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	private void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle") {
			if (spawning) {
				Instantiate (enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			spawning = true;
			SceneManager.LoadScene ("Battle");
		}
	}
}
