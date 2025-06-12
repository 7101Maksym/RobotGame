using System;
using System.Collections;
using TreeEditor;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Shoot _shootingScript;
    private EnemyDamagedScript _enemyHealths;

	private float _rotateSpeed = 50;
    private bool _canSetRotate = true;

    [SerializeField] private int _speed = 4;
    [SerializeField] private float _deathZone;

    private Vector2 _directon, _target;
    private int _rotate;

    public Transform PlayerTransform;
    public Transform RestorePackTransform;

    public bool PlayerFinded = false, CanSee = true, SetDeathZone = true;
    public bool RestorePackFinded = false, RestorePackCanSee = false;
    
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
        _enemyHealths = GetComponent<EnemyDamagedScript>();

        _rotate = UnityEngine.Random.Range(-180, 180);
    }

    private void FixedUpdate()
    {
        _rotate = GetRotateAngle(_target);

        if (RestorePackFinded && RestorePackCanSee && _enemyHealths.myHealths < _enemyHealths.maxHealths)
        {
            _target = RestorePackTransform.position;
        }
        else
        {
            if (PlayerFinded && CanSee)
            {
                _target = PlayerTransform.position;
            }
            else
            {
                if (_canSetRotate && _rotate == 0)
                {
                    StartCoroutine(SetNewRotate());
                }
            }
        }
        
        if (_rotate != 0)
        {
            _rb.rotation += _rotateSpeed * Time.fixedDeltaTime * _rotate;
        }
        else
        {
            if (PlayerFinded && CanSee && !(RestorePackCanSee && RestorePackFinded && _enemyHealths.myHealths < _enemyHealths.maxHealths) && _rotate == 0)
            {
                _shootingScript.Shooting();
            }

            if (Vector2.Distance(transform.position, _target) >= _deathZone)
            {
                _directon = transform.up;
                _rb.MovePosition(_rb.position + _directon * _speed * Time.fixedDeltaTime);
            }
            else
            {
                if (!SetDeathZone)
                {
                    _directon = transform.up;
                    _rb.MovePosition(_rb.position + _directon * _speed * Time.fixedDeltaTime);
                }
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
