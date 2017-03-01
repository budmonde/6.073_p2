using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float spawnFrequency;

	public GameObject playerSpawner;

	bool alive;
	bool won;
	bool firstPass = true;

	public float sleepTime;
	public float dieTime;

	float lifespan;
	float timer;

	// Use this for initialization
	void Start () {
		lifespan = 0;
		timer = spawnFrequency;
	}

	void SpawnEnemy() {
		float rand = Random.Range (-10, 10) / 10f;
		timer = spawnFrequency + rand;
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
		lifespan += Time.deltaTime;

		if (lifespan > dieTime) {
			Destroy (gameObject);
		}
		if (lifespan > sleepTime) {
			if (timer > 0) {
				timer -= Time.deltaTime;
				if (timer <= 0) {
					SpawnEnemy ();
				}
			}
		}
	}
		}
	}
}