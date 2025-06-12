using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorePack : MonoBehaviour
{
    public int _restore;

    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        transform.rotation = _player.transform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<DamagedScript>().RestoreHealths(_restore);

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<EnemyDamagedScript>().RestoreHealths(_restore);

            Destroy(gameObject);
        }
    }
}
