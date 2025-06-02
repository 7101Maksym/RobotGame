using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autocannonbullet : MonoBehaviour
{
    public Rigidbody2D _rb;
    private Animator _animator;

    private IEnumerator Destr()
    {
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

        //_rb.AddRelativeForce(transform.up * 1000);

        StartCoroutine(Explosion());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(Explosion());

            StartCoroutine(Destr());
        }
    }
}
