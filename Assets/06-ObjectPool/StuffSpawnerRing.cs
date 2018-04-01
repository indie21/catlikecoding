using UnityEngine;

public class StuffSpawnerRing : MonoBehaviour
{
    public int _numberOfSpawners;
    public float _radius, _tiltAngle;
    public StuffSpawner _spawnPrefeb;
	public Material[] _stuffMaterials;

    void Awake()
    {
        for (int i = 0; i < _numberOfSpawners; i++)
        {
            CreateSpawner(i);
        }
    }

    void CreateSpawner(int index)
    {
        Transform rotater = new GameObject("Rotater").transform;
        rotater.SetParent(transform, false);
        rotater.localRotation =
            Quaternion.Euler(0f, index * 360f / _numberOfSpawners, 0f);

        StuffSpawner spawner = Instantiate<StuffSpawner>(_spawnPrefeb);
        spawner.transform.SetParent(rotater, false);
        spawner.transform.localPosition = new Vector3(0f, 0f, _radius);
        spawner.transform.localRotation = Quaternion.Euler(_tiltAngle, 0f, 0f);
        spawner._stuffMaterial = _stuffMaterials[index % _stuffMaterials.Length];
    }
}
