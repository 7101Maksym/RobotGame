using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private GameObject _bullet;
	[SerializeField] private Transform _firstCoords, _secondCoords;
	[SerializeField] private Transform _bulletCapacitor;

	private Animator _animator;

	private bool _canShoot = true;

    private void Awake()
    {
		_animator = GetComponent<Animator>();
    }

    IEnumerator Reload()
	{
		_animator.SetBool("Shoot", false);

		yield return new WaitForSeconds(2);

		_canShoot = true;
	}

	IEnumerator SelectPosition()
	{
		_animator.SetBool("Shoot", true);

		yield return new WaitForSeconds(0.2f);

		_bullet.transform.position = _firstCoords.position;

		Instantiate(_bullet, _bulletCapacitor);
        
		yield return new WaitForSeconds(0.1f);

        _bullet.transform.position = _secondCoords.position;

        Instantiate(_bullet, _bulletCapacitor);
    }

	public void Shooting()
	{
		if (_canShoot)
		{
			_canShoot = false;

			StartCoroutine(SelectPosition());
            StartCoroutine(Reload());
		}
	}
}
