using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Transform _prefeb;
    public KeyCode _createKey = KeyCode.C;
    public KeyCode _newGameKey = KeyCode.N;
    public KeyCode _saveGameKey = KeyCode.S;
    public KeyCode _loadGameKey = KeyCode.L;

    List<Transform> _objects;
    string _savePath;

    void Awake()
    {
        _objects = new List<Transform>();
        _savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }

    void Update()
    {
        if (Input.GetKeyDown(_createKey))
        {
            CreateObject();
        }
        else if (Input.GetKeyDown(_newGameKey))
        {
            BeginNewGame();
        }
        else if (Input.GetKeyDown(_saveGameKey))
        {
            Save();
        }
        else if (Input.GetKeyDown(_loadGameKey))
        {
            Load();
        }
    }

    void CreateObject()
    {
        Transform t = Instantiate(_prefeb);
        t.localPosition = Random.insideUnitSphere * 5f;
        t.localRotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(0.1f, 1f);
        _objects.Add(t);
    }

    void BeginNewGame()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            Destroy(_objects[i].gameObject);
        }
        _objects.Clear();
    }

    void Save()
    {
        using (var writer = new BinaryWriter(File.Open(_savePath, FileMode.Create)))
        {
            writer.Write(_objects.Count);
            foreach (var t in _objects)
            {
                writer.Write(t.localPosition.x);
                writer.Write(t.localPosition.y);
                writer.Write(t.localPosition.z);
            }
        }
    }

    void Load()
    {
        BeginNewGame();
        using (var reader = new BinaryReader(File.Open(_savePath, FileMode.Open)))
        {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Vector3 p;
                p.x = reader.ReadSingle();
                p.y = reader.ReadSingle();
                p.z = reader.ReadSingle();

                var t = Instantiate(_prefeb);
                t.localPosition = p;
                _objects.Add(t);
            }
        }
    }

}
