using System;
using System.Collections;
using TreeEditor;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Shoot _shootingScript;

	private float _rotate, _rotateSpeed = 50, _plRotate;
    private bool _canSetRotate = true;

    [SerializeField] private int _speed = 4;

    private Vector2 _directon;

    public Transform _playerTransform;

    public bool _playerFinded = false, _canSee = true;
    
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
        _shootingScript = GetComponentInChildren<Shoot>();

        _rotate = UnityEngine.Random.Range(-180, 180);
    }

    private void FixedUpdate()
    {
        if (_playerTransform.position.x > transform.position.x)
        {
            _plRotate = -Vector2.Angle(new Vector2(0, 1), new Vector2(_playerTransform.position.x - transform.position.x, _playerTransform.position.y - transform.position.y));
        }
        else
        {
            _plRotate = Vector2.Angle(new Vector2(0, 1), new Vector2(_playerTransform.position.x - transform.position.x, _playerTransform.position.y - transform.position.y));
        }

        if (_playerFinded)
        {
            if (_canSee)
            {
                _rotate = _plRotate;
            }
        }

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

            if (_canSetRotate && (!_playerFinded || !_canSee))
            {
                StartCoroutine(SetNewRotate());
            }

            if (_playerFinded && _canSee)
            {
                _shootingScript.Shooting();
            }

            _directon = transform.up;
            _rb.MovePosition(_rb.position + _directon * _speed * Time.fixedDeltaTime);
        }
    }
}
