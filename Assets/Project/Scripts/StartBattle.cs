using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;

		gameObject.SetActive (false);
	}

	private void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (scene.name == "Title") {
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (gameObject);
		} else {
			gameObject.SetActive (scene.name == "Battle");
		}
	}
}
