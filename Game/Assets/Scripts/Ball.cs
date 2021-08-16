using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{

    float _speed = 20f;
    Rigidbody _body;
    Vector3 _velocity;
    Renderer _renderer;
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        
        _renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
    }

    void Launch()
    {
        _body.velocity = Vector3.up * _speed;
    }
    
    void FixedUpdate()
    {
        _body.velocity = _body.velocity.normalized * _speed;
        _velocity = _body.velocity;

        if (!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _body.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }

}
