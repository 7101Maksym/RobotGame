using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autocannonbullet : MonoBehaviour
{
    public Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
