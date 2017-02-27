using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour {

	public float normalSpeed;
	public float sprintSpeed;
	public float sightLength;
	public float meanderTime;

	float speed;
	float meandercd = 0f;
	float objectBoundaryRadius = 0.5f;
	Vector3 lastDir;
	Transform wizard;

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

		Vector3 dir = wizard.position - transform.position;

		if (dir.magnitude >= sightLength) { 
			dir = new Vector3 (Random.Range (-10, 10), Random.Range (-10, 10));
			speed = normalSpeed;
			if (meandercd >= 0) {
				meandercd -= Time.deltaTime;
				dir = lastDir;
			}
			else
				meandercd = meanderTime;
		} else {
			speed = sprintSpeed;
		}

		dir.Normalize ();

		lastDir = dir;

		Vector3 pos = transform.position;
		pos.y += dir.y * speed * Time.deltaTime;
		pos.x += dir.x * speed * Time.deltaTime;

		if (pos.y + objectBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - objectBoundaryRadius;
		}
		if (pos.y - objectBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + objectBoundaryRadius;
		}

		float screenRatio = (float) Screen.width / (float) Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x + objectBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - objectBoundaryRadius;
		}
		if (pos.x - objectBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + objectBoundaryRadius;
		}

		transform.position = pos;

	}
}
