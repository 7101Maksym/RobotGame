using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private PlayerInput _input;
	public Rigidbody2D _rb;

    [SerializeField] private int _maxSpeed;
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private float _factor;

    public bool CanMove = true;
    private float _speed = 0;
	private Vector2 _direction;
    private float _rotation;

	private void Awake()
	{
        _input = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_input.UpDown != 0)
        {
            if (Math.Abs(_speed) < _maxSpeed)
            {
                _speed += _factor * _input.UpDown;
            }
        }
        else
        {
            if (Math.Abs(_speed) - _factor >= 0)
            {
                _speed -= (_factor * _speed) / Math.Abs(_speed);
            }
            else
            {
                _speed = 0;
            }
        }

        _direction = transform.up;
        _rotation = _input.LeftRight * _rotateSpeed;
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            _rb.MovePosition(_rb.position + _direction * _speed * Time.fixedDeltaTime);
            _rb.rotation -= _rotation * Time.fixedDeltaTime;
        }
    }
}
