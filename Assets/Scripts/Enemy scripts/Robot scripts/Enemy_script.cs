using System;
using System.Collections;
using TreeEditor;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    private Rigidbody2D _rb;

	private float _rotate, _rotateSpeed = 50;
    private bool _canSetRotate = true;

    [SerializeField] private int _speed;

    private Vector2 _directon;

    [SerializeField] private Transform _playerTransform;

    public bool _playerFinded = false;
    
	IEnumerator SetNewRotate()
	{
        _canSetRotate = false;

        yield return new WaitForSeconds(5);

        _rotate = UnityEngine.Random.Range(-180, 180);

        _canSetRotate = true;
	}

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rotate = UnityEngine.Random.Range(-180, 180);
    }

    private void FixedUpdate()
    {
        if (_rotate - _rb.rotation > 1)
        {
            _rb.rotation += _rotateSpeed * Time.fixedDeltaTime;
        }
        else if (_rotate - _rb.rotation < 0)
        {
            _rb.rotation -= _rotateSpeed * Time.fixedDeltaTime;
        }
        else
        {
            _rb.rotation = _rotate;

            if (_canSetRotate && !_playerFinded)
            {
                StartCoroutine(SetNewRotate());
            }
            else if (_playerFinded)
            {
                
            }

            _directon = transform.up;
            _rb.MovePosition(_rb.position + _directon * _speed * Time.fixedDeltaTime);
        }
    }
}
