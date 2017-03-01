using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour {

	public GameObject wizardPrefab;
	public GameObject familiarPrefab;

	GameObject wizardInstance;
	GameObject familiarInstance;

	public bool won = false;
	public bool alive = true;
	float endCountdown = 5;
	bool restart = false;
	Scene loadedLevel;

	// Use this for initialization
	void Start () {
		SpawnPlayer ();
		loadedLevel = SceneManager.GetActiveScene ();
	}

	void SpawnPlayer() {
		wizardInstance = (GameObject)Instantiate (wizardPrefab, transform.position, transform.rotation);
		wizardInstance.name = "Wizard";
		familiarInstance = (GameObject)Instantiate (familiarPrefab, transform.position, transform.rotation);
		familiarInstance.name = "Familiar";
	}
	
	// Update is called once per frame
	void Update () {
		if (wizardInstance == null && alive) {
			alive = false;
			Destroy (GameObject.Find ("Familiar"));
			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag ("Enemy") as GameObject[]) {
				Destroy(enemy);
			}
			Destroy (GameObject.Find ("EnemySpawner"));
		}
		else if (won == true) {
			alive = false;
			Destroy (GameObject.Find ("Familiar"));
			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag ("Enemy") as GameObject[]) {
				Destroy(enemy);
			}
			Destroy (GameObject.Find ("EnemySpawner"));
		}
		if (won || !alive) {
			endCountdown -= Time.deltaTime;
			if (endCountdown <= 0) {
				restart = true;
			}
		}
		if (restart) {
		
			if (Input.anyKey) {
				
				SceneManager.LoadScene (loadedLevel.buildIndex);
			}
		}
	}

	void OnGUI() {
		if (restart) {
			GUI.Label (new Rect ((Screen.width / 2 - 50)-5, Screen.height / 2 - 25, 100, 50), "Press Any Key to Play Again!");
		}
		else if (won) {
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "YOU WON!");
		}
		else if (!alive && wizardInstance == null) {
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over!");
		}

	}
}
