using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardShooting : MonoBehaviour {

	private int leftMouseButtonIndex = 0;
	public int manaPool = 100;
	public GameObject bombPrefab;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (Input.GetMouseButtonDown(leftMouseButtonIndex) && cooldownTimer <= 0 && manaPool > 0) {
			cooldownTimer = fireDelay;
			Instantiate (bombPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation);
//			Debug.Log(Input.mousePosition);
//			Debug.Log(transform.position);
			
		}
	}
}
