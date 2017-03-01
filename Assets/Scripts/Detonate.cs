using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonate : MonoBehaviour {

	public GameObject bombPrefab;
	public float fireDelay = 0.25f;


	Transform wizard;
	int mana;
	float cooldownTimer = 0;

	void Start() {
	}

	// Update is called once per frame
	void Update () {
		if (wizard == null) {
			GameObject go = GameObject.Find ("Wizard");

			if (go != null) {
				wizard = go.transform;
			}
		}

		// here wizard either exists or doesn't
		if (wizard == null)
			return;

		mana = wizard.GetComponent<WizardShooting> ().mana;

		cooldownTimer -= Time.deltaTime;

		if (Input.GetButtonDown ("Detonate") && cooldownTimer <= 0) {
			if (mana <= 0)
				return;
			wizard.GetComponent<WizardShooting> ().mana--;
			cooldownTimer = fireDelay;
			Instantiate (bombPrefab, transform.position, transform.rotation);
		}
	}
}
