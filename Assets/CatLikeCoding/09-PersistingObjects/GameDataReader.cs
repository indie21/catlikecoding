using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


public class GameDataReader
{
    readonly BinaryReader _reader;

    public GameDataReader(BinaryReader reader)
    {
        this._reader = reader;
    }

    public float ReadFloat()
    {
        return _reader.ReadSingle();
    }

    public float ReadInt()
    {
        return _reader.ReadInt32();
    }

    public Quaternion ReadQuaternion()
    {
		Quaternion value;
		value.x = _reader.ReadSingle();
		value.y = _reader.ReadSingle();
		value.z = _reader.ReadSingle();
		value.w = _reader.ReadSingle();

		return value;
    }

	public Vector3 ReadVector3()
	{
		Vector3 value;
		value.x = _reader.ReadSingle();
		value.y = _reader.ReadSingle();
		value.z = _reader.ReadSingle();

		return value;
	}


}
