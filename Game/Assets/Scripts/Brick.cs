using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int _hits = 1;
    public int _points = 100; 
    public Vector3 _rotate;
    public Material _hitMaterial;

    Material _orgMaterial;
    Renderer _rend;

    void Start()
    {
        transform.Rotate(_rotate * (transform.position.x + transform.position.y) * 0.1f);
        _rend = GetComponent<Renderer>();
        _orgMaterial = _rend.sharedMaterial;
    }

    
    void Update()
    {
        transform.Rotate(_rotate * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        _hits--;
        if(_hits == 0)
        {
            GameManager.Instance.Score += _points;
            Destroy(gameObject);
        }
        _rend.sharedMaterial = _hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
    }

    void RestoreMaterial()
    {
        _rend.sharedMaterial = _orgMaterial;
    }
}
