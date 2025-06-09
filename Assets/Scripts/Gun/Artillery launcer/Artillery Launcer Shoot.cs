using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArtilleryLauncerShoot : MonoBehaviour
{
	[SerializeField] private Bullet _bullet;

	private Transform _capacitor;
	private Animator _animator;

	public bool CanShoot { private get; set; } = true;

	private bool Reload { get; set; } = true;

	private IEnumerator ReloadGun()
	{
		yield return new WaitForSeconds(2);

		Reload = true;
	}

	private IEnumerator StopShoot()
	{
		yield return new WaitForSeconds(0.4f);

        _animator.SetBool("Shoot", false);
    }

    private IEnumerator StartShoot()
    {
        yield return new WaitForSeconds(0.3f);

        _bullet.transform.position = new Vector2(transform.position.x, transform.position.y);

		_bullet.gameObject.transform.rotation = transform.rotation;

		Instantiate(_bullet, _capacitor);
    }

    private void Awake()
	{
		_capacitor = GameObject.Find("Capacitor").transform;
		_animator = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && CanShoot && Reload)
		{
			Reload = false;

			_animator.SetBool("Shoot", true);

			StartCoroutine(StartShoot());
			StartCoroutine(StopShoot());

			StartCoroutine(ReloadGun());
		}
	}
}
