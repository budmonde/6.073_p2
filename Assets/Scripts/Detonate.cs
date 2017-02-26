using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonate : MonoBehaviour {

	public GameObject bombPrefab;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (Input.GetButtonDown ("Detonate") && cooldownTimer <= 0) {
			cooldownTimer = fireDelay;
			Instantiate (bombPrefab, transform.position, transform.rotation);
		}
	}
}
