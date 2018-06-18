using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public GameObject bow;
	public GameObject arrow;

	bool arrowIsReady = false;

	// Use this for initialization
	void Start () {
		readyBow ();
		readyArrow ();	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.Rotate (Vector3.forward);
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			transform.Rotate (Vector3.back);
		}

		if (arrowIsReady) {
			arrow.transform.rotation = transform.rotation;
		}

		if (Input.GetKey(KeyCode.Space)) {
			fire ();
		}

	}

	void fire () {
		Arrow arrowBehavior = (Arrow) arrow.GetComponent (typeof(Arrow));
		arrowBehavior.fire ();
		arrow.transform.parent = null;
		arrow.transform.rotation = Quaternion.Euler (0.0f, 0.0f, transform.rotation.z * -1.0f);
	}

	void readyBow() {
		bow = Instantiate (bow, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity);
		bow.transform.parent = transform;
	}

	void readyArrow() {
		arrow = Instantiate (arrow, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity);
		arrow.transform.parent = transform;
		arrowIsReady = true;
	}


}
