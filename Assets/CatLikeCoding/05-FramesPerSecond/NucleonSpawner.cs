// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class NucleonSpawner : MonoBehaviour {
	public float _timeBetweenSpawns;
	public float _spawnDistance;
	public Nucleon[] _nucleonPrefebs;


	float _timeSinceLastSpawn;

	void FixedUpdate() {
		_timeSinceLastSpawn += Time.deltaTime;
		if (_timeSinceLastSpawn >= _timeBetweenSpawns) {
			_timeSinceLastSpawn -= _timeBetweenSpawns;
			SpawnNucleon();
		}
	}

	void SpawnNucleon() {
		Nucleon prefeb = _nucleonPrefebs[Random.Range(0, _nucleonPrefebs.Length)];
		Nucleon spawn = Instantiate<Nucleon>(prefeb);
		spawn.transform.localPosition = Random.onUnitSphere * _spawnDistance;
	}
}
