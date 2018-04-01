using UnityEngine;

public class StuffSpawner : MonoBehaviour
{

    public Stuff[] _stuffPrefebs;
    float _timeSinceLastSpawn;
    public float _velocity;
    public FloatRange _timeBetweenSpawns, _scale, _randomVelocity, _angularVelocity;
    float _currentSpawnDelay;
    public Material _stuffMaterial;

    void FixedUpdate()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= _currentSpawnDelay)
        {
            _timeSinceLastSpawn -= _currentSpawnDelay;
            _currentSpawnDelay = _timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
    }

    void SpawnStuff()
    {
        Stuff prefeb = _stuffPrefebs[Random.Range(0, _stuffPrefebs.Length)];
        Stuff spawn = prefeb.GetPooledInstance<Stuff>();

        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = Vector3.one * _scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;
        spawn.Body.velocity = transform.up * _velocity +
			Random.onUnitSphere * _randomVelocity.RandomInRange;
        spawn.Body.angularVelocity =
			Random.onUnitSphere * _angularVelocity.RandomInRange;
        spawn.SetMaterial(_stuffMaterial);
    }

}
