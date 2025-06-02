using System.Collections;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private Autocannonbullet _bullet;
	[SerializeField] private Transform _firstCoords, _secondCoords;
	
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
		_animator.SetBool("Shoot", false);

		yield return new WaitForSeconds(2);

		_canShoot = true;
	}

	IEnumerator SelectPosition1()
	{
		_animator.SetBool("Shoot", true);

		yield return new WaitForSeconds(0.2f);

		Instantiate(_bullet, _capacitor);

		_bullet.transform.position = new Vector2(_firstCoords.position.x, _firstCoords.position.y);

		_bullet.gameObject.transform.rotation = transform.rotation;

		StartCoroutine(SelectPosition2());
    }

    IEnumerator SelectPosition2()
    {
        yield return new WaitForSeconds(0.1f);

        Instantiate(_bullet, _capacitor);

        _bullet.transform.position = new Vector2(_secondCoords.position.x, _secondCoords.position.y);

        _bullet.gameObject.transform.rotation = transform.rotation;

        StartCoroutine(Reload());
    }

    public void Shooting()
	{
		if (_canShoot)
		{
			_canShoot = false;

			StartCoroutine(SelectPosition1());
		}
	}
}
