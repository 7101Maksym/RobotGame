using System.Collections;
using UnityEngine;

public class Enemy_generator : MonoBehaviour
{
	[SerializeField] private GameObject _enemy;
	[SerializeField] private Transform _enemyCapacitor;
    [SerializeField] private int _countEnemys = 20;

    public int BeatedEnemys = 0;

	private bool _canAdd = true;

	IEnumerator AddEnemy()
	{
		yield return new WaitForSeconds(5);

        Instantiate(_enemy, _enemyCapacitor);

        _enemy.transform.position = new Vector2(Random.Range(-70, 50), Random.Range(-33, 30));

		_canAdd = true;
    }

    private void Update()
    {
        if (_canAdd && _enemyCapacitor.transform.childCount < _countEnemys)
        {
            _canAdd = false;

            StartCoroutine(AddEnemy());
        }
    }
}
