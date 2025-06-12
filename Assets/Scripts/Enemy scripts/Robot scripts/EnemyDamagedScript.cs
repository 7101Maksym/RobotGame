using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamagedScript : MonoBehaviour
{
    [SerializeField] private float _maxHealths;
    [SerializeField] private int _randParametrs;
    [SerializeField] private GameObject _rechargePack;
    
    private Transform _rechargePackCapacitor;
    private SpriteRenderer _renderer;

    public float myHealths = 20;

    private float _delta;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _rechargePackCapacitor = GameObject.Find("RechargeCapacitor").transform;
    }

    private void Update()
    {
        _delta = (((_maxHealths - myHealths) * 155f) / (_maxHealths - 1f)) / 255f;

        _renderer.color = new Color(1f - _delta, 1f - _delta, 1f - _delta);

        if (myHealths <= 0)
        {
            Destroy(gameObject);

            if (Random.Range(0, 100) <= _randParametrs)
            {
                _rechargePack.transform.position = transform.position;

                Instantiate(_rechargePack, _rechargePackCapacitor);
            }
        }
    }

    public void RechargeHealths(int recharge)
    {
        if (myHealths == _maxHealths)
        {
            return;
        }
        else if (myHealths + recharge >= _maxHealths)
        {
            myHealths = _maxHealths;
        }
        else
        {
            myHealths += recharge;
        }
    }
}
