// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

	public float _attractionForce;
	Rigidbody _body;

	void Awake () {
		_body = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		_body.AddForce(transform.localPosition *  -_attractionForce);
	}

	// Update is called once per frame
	void Update () {
	}
}
