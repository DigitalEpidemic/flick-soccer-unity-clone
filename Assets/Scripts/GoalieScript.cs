using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalieScript : MonoBehaviour {
	
	private float maxX = 1.22f;
	private float minX = -1.22f;
	private bool moveLeft = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveInNet ();
	}

	void MoveInNet () {
		if (moveLeft) {
			if (transform.position.x > minX) {
				Vector3 location = transform.position;
				location.x -= 4.5f * Time.deltaTime;
				transform.position = location;
			} else {
				moveLeft = false;
			}
		} else {
			if (transform.position.x < maxX) {
				Vector3 location = transform.position;
				location.x += 4.5f * Time.deltaTime;
				transform.position = location;
			} else {
				moveLeft = true;
			}
		}
	}
}
