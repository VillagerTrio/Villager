﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public GameObject bow;
	public GameObject arrow;

	float timeSinceLastShot = 0f;
	bool arrowIsReady = false;

	// Use this for initialization
	void Start () {
		readyBow ();
		readyArrow ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!arrowIsReady) {
			if (timeSinceLastShot > 1.5f) {
				timeSinceLastShot = 0;
				readyArrow ();	
			} else {
				timeSinceLastShot += Time.deltaTime;
			}
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.Rotate (Vector3.forward);
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			transform.Rotate (Vector3.back);
		}

		if (Input.GetKey(KeyCode.Space)) {
			fire ();
		}

	}

	void fire () {
		if (arrowIsReady) {
			Arrow arrowBehavior = (Arrow) arrow.GetComponent (typeof(Arrow));
			arrowBehavior.fire ();
			arrowIsReady = false;
		}
	}

	void readyBow() {
		bow = Instantiate (bow, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity);
		bow.transform.parent = transform;
	}

	void readyArrow() {
		GameObject newArrow = (GameObject) Resources.Load ("arrow");
		Vector3 initialPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		arrow = Instantiate (newArrow, initialPos, transform.rotation);
		arrow.transform.parent = transform;
		arrowIsReady = true;
	}


}
