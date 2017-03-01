using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardShooting : MonoBehaviour {

	private int leftMouseButtonIndex = 0;
	public GameObject bombPrefab;
	public int maxMana;
	public float regenTimer;

	private Vector2 bombPlacement;
	public float fireDelay = 0.25f;
	public int mana;
	float regencd;
	float cooldownTimer = 0;

	void Start() {
		mana = maxMana;
		regencd = regenTimer;
	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;


		if (Input.GetMouseButtonDown(leftMouseButtonIndex) && cooldownTimer <= 0 && mana > 0) {

		if (mana < maxMana) {
			if (regencd <= 0) {
				mana++;
				regencd = regenTimer;
			} else {
				regencd -= Time.deltaTime;
			}
		}

		if (Input.GetMouseButtonDown(leftMouseButtonIndex) && cooldownTimer <= 0 && mana > 0) {
			cooldownTimer = fireDelay;
			Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			position.z = 0;
			Instantiate (bombPrefab, position, transform.rotation);
			mana--;
			}	
		}
	}
}