using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarMovement : MonoBehaviour {

	public float maxSpeed;
	float objectBoundaryRadius = 0.5f*0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 pos = transform.position;
		pos.y += Input.GetAxis("F_Vertical") * maxSpeed * Time.deltaTime;
		pos.x += Input.GetAxis("F_Horizontal") * maxSpeed * Time.deltaTime;

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
