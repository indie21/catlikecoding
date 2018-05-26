using UnityEngine;

[System.Serializable]
public struct FloatRange
{
    public float _min, _max;
    public float RandomInRange
    {
        get
        {
            return Random.Range(_min, _max);
        }
    }
}
