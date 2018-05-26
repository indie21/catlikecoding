using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {

	public Mesh _mesh;
	public Material _material;

	public int _maxDepth;
	private int _depth;
	public float _childScale;

	private Material[] _materials;


	private void InitializeMaterials () {
		_materials = new Material[_maxDepth + 1];
		for (int i = 0; i <= _maxDepth; i++) {
			_materials[i] = new Material(_material);
			_materials[i].color = Color.Lerp(Color.white, Color.yellow, (float)i / _maxDepth);
		}

		_materials[_maxDepth].color = Color.magenta;
	}

	// Use this for initialization
	private void Start () {

		if (_materials == null) {
			InitializeMaterials();
		}

		Debug.Log("start");
		Debug.Log(_depth);
		Debug.Log(_maxDepth);
		gameObject.AddComponent<MeshFilter>().mesh = _mesh;
		gameObject.AddComponent<MeshRenderer>().material = _material;

		GetComponent<MeshRenderer>().material = _materials[_depth];

		if(_depth < _maxDepth)  {
			StartCoroutine(CreateChildren());
		}
	}

	private IEnumerator CreateChildren() {
		yield return new WaitForSeconds(0.5f);
		new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.up);
		yield return new WaitForSeconds(0.5f);
		new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.right);
		yield return new WaitForSeconds(0.5f);
		new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.left);
	}

	private void Initialize(Fractal parent, Vector3 direction) {
		_materials = parent._materials;
		_mesh = parent._mesh;
		_material = parent._material;
		_depth = parent._depth +1;
		_maxDepth = parent._maxDepth;
		_childScale = parent._childScale;
		transform.parent = parent.transform;

		transform.localScale = Vector3.one * _childScale;
		transform.localPosition = direction* (0.5f + 0.5f * _childScale);
	}

	// Update is called once per frame
	void Update () {

	}
}
