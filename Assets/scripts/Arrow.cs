using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void fire() {
		body.velocity = new Vector2 (50, 0);
	}
}
