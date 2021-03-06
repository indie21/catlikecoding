﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{

    private Mesh _mesh;
    public int _xSize, _ySize;
    private Vector3[] _vertices;

    private void Awake()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        var wait = new WaitForSeconds(0.02f);

        GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
        _mesh.name = "Procedural Grid";

        _vertices = new Vector3[(_xSize + 1) * (_ySize + 1)];
        Vector2[] uv = new Vector2[_vertices.Length];
		Vector4[] tangents = new Vector4[_vertices.Length];
		Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
        for (int i = 0, y = 0; y <= _ySize; y++)
        {
            for (int x = 0; x <= _xSize; x++, i++)
            {
                _vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / _xSize, (float)y / _ySize);
				tangents[i] = tangent;
				//uv[i] = new Vector2(x / _xSize, y / _ySize);
                yield return wait;
            }
        }

        _mesh.vertices = _vertices;
        _mesh.uv = uv;
		_mesh.tangents = tangents;

		// int[] triangles = new int[6];
		// triangles[0] = 0;
		// triangles[1] = xSize + 1;
		// triangles[2] = 1;
		//
		// triangles[3] = 1;
		// triangles[4] = xSize + 1;
		// triangles[5] = xSize + 2;

        int[] triangles = new int[_xSize * _ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < _ySize; y++, vi++)
        {
            for (int x = 0; x < _xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + _xSize + 1;
                triangles[ti + 5] = vi + _xSize + 2;
            }
        }

        _mesh.triangles = triangles;
        _mesh.RecalculateNormals();

    }

    private void OnDrawGizmos()
    {
        if (_vertices == null)
        {
            return;
        }

        Gizmos.color = Color.black;
        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(_vertices[i], 0.1f);
        }
    }

}
