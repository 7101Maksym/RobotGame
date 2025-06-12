using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private int _speed = 500;
    [SerializeField] private int[] _layersWithHealths, _excludeLayers;

    public Rigidbody2D _rb;
    private Animator _animator;

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
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, _rb.transform.up, Color.red);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!InArray(_excludeLayers, collision.gameObject.layer) && collision.isTrigger == false)
        {
            if (InArray(_layersWithHealths, collision.gameObject.layer))
            {
                if (collision.gameObject.GetComponentInParent<DamagedScript>())
                {
                    collision.gameObject.GetComponentInParent<DamagedScript>().myHealths -= _damage;
                }
                else if (collision.gameObject.GetComponentInParent<EnemyDamagedScript>())
                {
                    collision.gameObject.GetComponentInParent<EnemyDamagedScript>().myHealths -= _damage;
                }


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
