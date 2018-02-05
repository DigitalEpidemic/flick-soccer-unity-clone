using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject ballPrefab;

	[SerializeField]
	private float ballForce;

	private GameObject ballInstance;

	private Vector3 mouseStart, mouseEnd;

	private float minFlickDistance = 15f;
	private float zDepth = 25f;

	void Awake () {
	}

	// Use this for initialization
	void Start () {
		CreateBall ();
	}
	
	// Update is called once per frame
	void Update () {
		FlickAction ();
	}

	void CreateBall () {
		ballInstance = Instantiate (ballPrefab, ballPrefab.transform.position, Quaternion.identity);
	}

	void FlickAction () {
		if (Input.GetMouseButtonDown (0)) {
			mouseStart = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp (0)) {
			mouseEnd = Input.mousePosition;

			if (Vector3.Distance (mouseEnd, mouseStart) > minFlickDistance) {
				// Kick ball
				Vector3 hitPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zDepth);
				hitPos = Camera.main.ScreenToWorldPoint (hitPos);
				ballInstance.transform.LookAt (hitPos);
				ballInstance.GetComponent<Rigidbody> ().AddRelativeForce (ballInstance.transform.forward * ballForce, ForceMode.Impulse);

				Invoke ("CreateBall", 2f);
			}
		}
	}

} // GameController