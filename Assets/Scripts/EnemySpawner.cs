using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float spawnFrequency;

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
		if (timer > 0) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				SpawnEnemy ();
			}
		}
	}
}
