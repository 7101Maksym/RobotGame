using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamagedScript : MonoBehaviour
{
    
    [SerializeField] private int _randParametrs;
    [SerializeField] private GameObject _restorePack;
    
    private Transform _restorePackCapacitor;
    private SpriteRenderer _renderer;
    private Enemy_generator _base;

    public float maxHealths;
    public float myHealths = 20;

    private float _delta;

    private void Awake()
    {
        _base = GameObject.Find("Enemy_generator").GetComponent<Enemy_generator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _restorePackCapacitor = GameObject.Find("RestoreCapacitor").transform;
    }

    private void Update()
    {
        _delta = (((maxHealths - myHealths) * 155f) / (maxHealths - 1f)) / 255f;

        _renderer.color = new Color(1f - _delta, 1f - _delta, 1f - _delta);

        if (myHealths <= 0)
        {
            _base.BeatedEnemys++;

            Destroy(gameObject);

            if (Random.Range(0, 100) <= _randParametrs)
            {
                _restorePack.transform.position = transform.position;

                Instantiate(_restorePack, _restorePackCapacitor);
            }
        }
    }

    public void RestoreHealths(int restore)
    {
        if (myHealths == maxHealths)
        {
            return;
        }
        else if (myHealths + restore >= maxHealths)
        {
            myHealths = maxHealths;
        }
        else
        {
            myHealths += restore;
        }
    }
}
