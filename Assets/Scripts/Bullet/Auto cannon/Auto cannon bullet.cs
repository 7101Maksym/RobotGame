using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autocannonbullet : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private int _speed = 500;

    public Rigidbody2D _rb;
    private Animator _animator;

    private IEnumerator Destr()
    {
        _rb.AddForce(-_rb.transform.up * _speed);

        _animator.SetBool("IsDestroyed", true);

        yield return new WaitForSeconds(0.8f);

        Destroy(gameObject);
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2);

        StartCoroutine(Destr());
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        _rb.AddForce(_rb.transform.up * _speed);

        StartCoroutine(Explosion());
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, _rb.transform.up, Color.red);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<DamagedScript>().myHealths -= _damage;

            StopCoroutine(Explosion());

            StartCoroutine(Destr());
        }
    }
}
