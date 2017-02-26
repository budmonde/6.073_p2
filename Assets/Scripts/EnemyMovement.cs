using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float maxSpeed;
	float objectBoundaryRadius = 0.5f;
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
		dir.Normalize ();

		Vector3 pos = transform.position;
		pos.y += dir.y * maxSpeed * Time.deltaTime;
		pos.x += dir.x * maxSpeed * Time.deltaTime;

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
