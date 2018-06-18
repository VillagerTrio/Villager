using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

	public Camera cam;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5f;

		Vector3 objPos = cam.WorldToScreenPoint (transform.position);

		mousePos.x = mousePos.x - objPos.x;
		mousePos.y = mousePos.y - objPos.y;

		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle + 75));
	}

	void fire () {

	}
}
