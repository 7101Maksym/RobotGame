using System.Collections;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Transform _firstCoords;
	[SerializeField] private Transform _secondCoords;

	private Vector2 _f, _s;
	
	private Transform _capacitor;
	private Animator _animator;

	private bool _canShoot = true;

    private void Awake()
    {
		_animator = GetComponent<Animator>();
		_capacitor = GameObject.Find("Capacitor").transform;
    }

    IEnumerator Reload()
	{
		yield return new WaitForSeconds(2);

		_canShoot = true;
	}

	IEnumerator SelectPosition1()
	{
		yield return new WaitForSeconds(0.2f);

		_bullet.transform.position = new Vector2(_f.x, _f.y);

		_bullet.gameObject.transform.rotation = transform.rotation;

		_bullet.Self = gameObject;

		Instantiate(_bullet, _capacitor);
		
		StartCoroutine(SelectPosition2());
    }

    IEnumerator SelectPosition2()
    {
        yield return new WaitForSeconds(0.1f);

		_bullet.transform.position = new Vector2(_s.x, _s.y);

		_bullet.gameObject.transform.rotation = transform.rotation;

        _bullet.Self = gameObject;

        Instantiate(_bullet, _capacitor);

		_animator.SetBool("Shoot", false);

		StartCoroutine(Reload());
    }

    public void Shooting()
	{
		if (_canShoot)
		{
			_canShoot = false;

            _animator.SetBool("Shoot", true);

            StartCoroutine(SelectPosition1());
		}
	}

    private void Update()
    {
		_f = _firstCoords.position;
		_s = _secondCoords.position;
    }
}
