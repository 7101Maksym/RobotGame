using UnityEngine;

public class Enemy_generator : MonoBehaviour
{
	[SerializeField] private GameObject _enemy;
	[SerializeField] private Transform _enemyCapacitor;

	private void Awake()
	{
		Instantiate(_enemy, _enemyCapacitor);
	}
}
