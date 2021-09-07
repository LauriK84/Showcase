using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject winText;
    public float _speed;
    public float _rotation;
    float _rot;
    int _score;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(_mousePos.x < 0)
            {
                _rot = _rotation;
            }
            else
            {
                _rot = -_rotation;
            }
            transform.Rotate(0, 0, _rot * Time.deltaTime);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f),
            Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);
    }
     void FixedUpdate()
    {
        rb.velocity = transform.up * _speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fish")
        {
            Destroy(collision.gameObject);
            _score++;

            if(_score >= 6)
            {
                print("Level Complete!!!");
                winText.SetActive(true);
            }
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
