using System.Collections;
using UnityEngine;

public class Enemy_generator : MonoBehaviour
{
	[SerializeField] private GameObject _enemy;
	[SerializeField] private Transform _enemyCapacitor;

	private bool _canAdd = true;

	IEnumerator AddEnemy()
	{
		yield return new WaitForSeconds(5);

        Instantiate(_enemy, _enemyCapacitor);

        _enemy.transform.position = new Vector2(UnityEngine.Random.Range(-70, 50), UnityEngine.Random.Range(-33, 30));

		_canAdd = true;
    }

    private void Update()
    {
        if (_canAdd && _enemyCapacitor.transform.childCount < 20)
        {
            _canAdd = false;

            StartCoroutine(AddEnemy());
        }
    }
}
