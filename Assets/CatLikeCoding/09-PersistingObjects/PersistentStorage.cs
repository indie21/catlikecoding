using System.IO;
using UnityEngine;

public class PersistentStorage: MonoBehaviour
{
    string _savePath;

    void Awake()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }

    public void Save(PersistentObject o)
    {
        using (var writer = new BinaryWriter(File.Open(_savePath, FileMode.Open)))
        {
            o.Save(new GameDataWriter(writer));
        }
    }

    public void Load(PersistentObject o)
    {
		using (var reader = new BinaryReader(File.Open(_savePath, FileMode.Open)))
		{
			o.Load(new GameDataReader(reader));
		}
    }


}
