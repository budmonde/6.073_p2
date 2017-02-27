using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour {

	public float maxSpeed;
	float objectBoundaryRadius = 0.5f * 0.3f;

	// Use this for initialization
	void Start () {
	}

	void Move(float x, float y) {

		Vector3 pos = transform.position;
		pos.y += y * maxSpeed * Time.deltaTime;
		pos.x += x * maxSpeed * Time.deltaTime;


		if (pos.y + objectBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - objectBoundaryRadius;
		}
		if (pos.y - objectBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + objectBoundaryRadius;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x + objectBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - objectBoundaryRadius;
		}
		if (pos.x - objectBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + objectBoundaryRadius;
		}

		transform.position = pos;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis ("W_Horizontal");
		float y = Input.GetAxis ("W_Vertical");
		Move (x, y);
	}
}
