﻿using System.Collections;
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
		Vector3 axis = Vector3.zero;
		float angle = 0f;
		transform.rotation.ToAngleAxis(out angle, out axis);
		angle = axis.z > 0 ? angle : 360f - angle;
		transform.parent = null;
		body.velocity = this.angle2Velocity (angle);
	}

	Vector2 angle2Velocity(float a){
		a *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a)) * 50;
	}

	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		body.velocity = new Vector2 (0, 0);
	}
}
