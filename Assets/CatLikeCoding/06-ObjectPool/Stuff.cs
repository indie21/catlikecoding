using UnityEngine;


public class Stuff : PooledObject
{
    public Rigidbody Body{ get; private set; }

    MeshRenderer[] _meshRenderers;

    void Awake()
    {
        Body = GetComponent<Rigidbody>();
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void SetMaterial(Material m)
    {
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            _meshRenderers[i].material = m;
        }
    }

    void OnTriggerEnter(Collider enteredCollider)
    {
        if (enteredCollider.CompareTag("kill zone"))
        {
            //Debug.Log("destroy stuff");
            //Destroy(gameObject);
			ReturnToPool();
        }
    }

}
