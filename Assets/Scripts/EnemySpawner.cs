using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float spawnFrequency;
	public GameObject playerSpawner;

	bool alive;
	bool won;
	bool firstPass = true;
	float timer;

	// Use this for initialization
	void Start () {
		timer = spawnFrequency;
	}

	void SpawnEnemy() {
		timer = spawnFrequency;
		GameObject enemyInstance = (GameObject) Instantiate (enemyPrefab, transform.position, transform.rotation);
		enemyInstance.name = "Enemy";
	}
	
	// Update is called once per frame
	void Update () {
		if (firstPass){
			playerSpawner = GameObject.Find("PlayerSpawner");
			firstPass = false;
		}

		alive = playerSpawner.GetComponent<PlayerSpawner> ().alive;
		won = playerSpawner.GetComponent<PlayerSpawner> ().won;

		if (timer > 0) {
			if (alive && !won) {
				timer -= Time.deltaTime;
			}
			if (timer <= 0) {
				SpawnEnemy ();
			}
		}
	}
}
