using System;
using System.Collections;
using TreeEditor;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Shoot _shootingScript;

	private float _rotateSpeed = 50;
    private bool _canSetRotate = true;

    [SerializeField] private int _speed = 4;
    [SerializeField] private float _deathZone;

    private Vector2 _directon, _target;
    private int _rotate;

    public Transform _playerTransform;

    public bool _playerFinded = false, _canSee = true, SetDeathZone = true;
    
	IEnumerator SetNewRotate()
	{
        _canSetRotate = false;

        yield return new WaitForSeconds(5);

        _target = new Vector2(UnityEngine.Random.Range(-70, 50), UnityEngine.Random.Range(-33, 30));

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
        _rotate = GetRotateAngle(_target);

        if (_playerFinded && _canSee)
        {
            _target = _playerTransform.position;
        }
        else
        {
            if (_canSetRotate && _rotate == 0)
            {
                StartCoroutine(SetNewRotate());
            }
        }
        
        if (_rotate != 0)
        {
            _rb.rotation += _rotateSpeed * Time.fixedDeltaTime * _rotate;
        }
        else
        {
            if (_playerFinded && _canSee)
            {
                _shootingScript.Shooting();
            }

            if (Vector2.Distance(transform.position, _target) >= _deathZone && SetDeathZone)
            {
                _directon = transform.up;
                _rb.MovePosition(_rb.position + _directon * _speed * Time.fixedDeltaTime);
            }
            else
            {
                _directon = transform.up;
                _rb.MovePosition(_rb.position + _directon * _speed * Time.fixedDeltaTime);
            }
        }
    }

    private int GetRotateAngle(Vector2 target)
    {
        float controlAngle;

        controlAngle = Vector2.Angle(transform.right.normalized, new Vector2(target.x - transform.position.x, target.y - transform.position.y).normalized);

        if (controlAngle < 89)
        {
            return -1;
        }
        else if (controlAngle > 91)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _deathZone);
    }
}
