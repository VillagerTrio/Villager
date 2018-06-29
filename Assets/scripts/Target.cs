using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	bool hitted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject gameObj = GameObject.Find ("Scoring");
		Scoring scoring = (Scoring) gameObj.GetComponent ((typeof(Scoring)));
		int points = inferPoints (collider.transform.position.y);
		scoring.addPoints (points);
		if (!hitted) {
			hitted = true;
			scoring.newTargetHitted ();
		}
	}

	int inferPoints(float y) {
		Debug.Log (y);
		if (y >= 1.59f && y < 1.71f || y >= 0.9f && y < 1.29f || y < -1.8f && y > -1.45f) {
			return 50;
		} else if (y > 1.15f && y < 1.59f || y > 1.71f && y <= 2.1f || y > 1.29f || y > -2.3f || y < 2.0f) {
			return 30;
		}
		return 10;
	}

}
