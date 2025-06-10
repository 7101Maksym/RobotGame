using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private int _speed = 500;
    [SerializeField] private int[] _layers;

    public Rigidbody2D _rb;
    public GameObject Self;
    private Animator _animator;
    private bool _active = false;

    private IEnumerator Destr()
    {
        _rb.velocity = Vector2.zero;

        _animator.SetBool("IsDestroyed", true);

        yield return new WaitForSeconds(0.8f);

        Destroy(gameObject);
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2);

        StartCoroutine(Destr());
    }

    private IEnumerator SetActive()
    {
        yield return new WaitForSeconds(0.02f);

        _active = true;
    }

    private bool InArray(int[] arr, int a)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == a)
            {
                return true;
            }
        }

        return false;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        _rb.AddForce(_rb.transform.up * _speed);
    }

    private void Start()
    {
        StartCoroutine(Explosion());
        StartCoroutine(SetActive());
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, _rb.transform.up, Color.red);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (_active)
        {
            if (InArray(_layers, collision.gameObject.layer))
            {
                collision.gameObject.GetComponentInParent<DamagedScript>().myHealths -= _damage;

                StopCoroutine(Explosion());

                StartCoroutine(Destr());
            }
            else
            {
                StopCoroutine(Explosion());

                StartCoroutine(Destr());
            }
        }
    }
}
