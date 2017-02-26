using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject wizardPrefab;
	public GameObject familiarPrefab;

	GameObject wizardInstance;
	GameObject familiarInstance;

	bool alive = true;

	// Use this for initialization
	void Start () {
		SpawnPlayer ();
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
	}

	void OnGUI() {
		if (!alive && wizardInstance == null) {
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over!");
		}
	}
}
