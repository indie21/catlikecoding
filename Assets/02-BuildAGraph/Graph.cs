// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform _pointPrefab;
	public delegate float GraphFunction(float x ,float z, float t );

	static readonly GraphFunction[] functions = {
		SinFunction,
		Sine2DFunction,
		MultiSinFunction,
	};

	public enum GraphFunctionName {
		Sin,
		Sine2D,
		MultiSin,
	};

	public GraphFunctionName _function;

	[Range(10, 100)]
	public int _resolution = 10;

	float _step;
	const float pi = Mathf.PI;

	Transform[] _points;

	// Use this for initialization
	void Start () {

	}

	static float SinFunction(float x, float z,float t ) {
		return Mathf.Sin(Mathf.PI * (x+ t));
	}

	static float Sine2DFunction (float x, float z, float t) {
		float y = Mathf.Sin(Mathf.PI * (x + t));
		y += Mathf.Sin(Mathf.PI * (z + t));
		y *= 0.5f;
		return y;
		//return Mathf.Sin(pi * (x + z + t));
	}

	static float MultiSinFunction(float x, float z, float t) {
		float y = Mathf.Sin(Mathf.PI *(x+t));
		y += Mathf.Sin(2f * Mathf.PI* (x+2f*t))/2f;
		y *= 2f/3f;
		return y;
	}

	void Awake() {
		_points = new Transform[_resolution*_resolution];
		_step = 2f / _resolution;

		Vector3 scale = Vector3.one * _step;
		Vector3 position;
		position.z = 0f;
		position.y = 0f;

		for (int i = 0, z = 0; z < _resolution; z++) {
			position.z = (z + 0.5f) * _step - 1f;
			for (int x = 0; x < _resolution; x++, i++) {
				Transform point = Instantiate(_pointPrefab);
				position.x = (x + 0.5f) * _step - 1f;
				point.localPosition = position;
				point.localScale = scale;
				point.SetParent(transform, false);
				_points[i] = point;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		float t = Time.time;

		GraphFunction f = functions[(int)_function];
		for (int i = 0, z = 0; z < _resolution; z++) {
			//position.z = (z + 0.5f) * _step - 1f;
			for (int x = 0; x < _resolution; x++, i++) {
				Transform point = _points[i];
				Vector3 position = point.localPosition;
				position.y = f(position.x,position.z,t);
				point.localPosition = position;
			}
		}



	}
}
