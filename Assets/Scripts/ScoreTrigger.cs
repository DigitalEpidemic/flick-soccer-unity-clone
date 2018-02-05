using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider target) {
		if (target.gameObject.tag == "Ball") {
			GameController.instance.score++;
		}
	}

} // ScoreTrigger