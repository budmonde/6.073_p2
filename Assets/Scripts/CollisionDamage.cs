using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour {

	public int health;
	public float invPeriod = 0;
	float invTimer = 0;
	int correctLayer;

	SpriteRenderer spriteRend;

	void Start() {
		correctLayer = gameObject.layer;
		spriteRend = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D() {
		health--;
		invTimer = invPeriod;
		gameObject.layer = 10;
	}

	void Update() {

		if (invTimer > 0) {
			invTimer -= Time.deltaTime;

			if (invTimer <= 0) {
				gameObject.layer = correctLayer;
				if (spriteRend != null) {
					spriteRend.enabled = true;
				}
			} else {
				if (spriteRend != null) {
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}
		if (health <= 0) {
			Die ();
		}
	}

	void Die() {
		if (gameObject.name == "Objective") {
			GameObject.Find ("PlayerSpawner").GetComponent<PlayerSpawner> ().won = true;
		}
		Destroy (gameObject);
	}
}
