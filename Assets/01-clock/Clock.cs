//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour {

	const float degreesPerHour = 30f;
	const float degreesPerMinute = 6f;
	const float degreesPerSecond = 6f;

	public Transform _hoursTransform;
	public Transform _minutesTransform;
	public Transform _secondsTransform;

	public bool _continuous;

	// Use this for initialization
	void Start () {
	}

	void UpdateContinuous () {
		TimeSpan time = DateTime.Now.TimeOfDay;

		_hoursTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
		_minutesTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
		_secondsTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
	}

	void UpdateDiscrete () {
		var value = Quaternion.Euler(0f, DateTime.Now.Hour * degreesPerHour, 0f);
		Debug.Log(value);
		_hoursTransform.localRotation = value;

		value = Quaternion.Euler(0f, DateTime.Now.Minute * degreesPerMinute, 0f);
		Debug.Log(value);
		_minutesTransform.localRotation = value;

		value = Quaternion.Euler(0f, DateTime.Now.Second * degreesPerSecond, 0f);
		Debug.Log(value);
		_secondsTransform.localRotation = value;
	}

	// Update is called once per frame
	void Update () {
		if (_continuous) {
			UpdateContinuous();
		}else{
			UpdateDiscrete();
		}
	}
}
