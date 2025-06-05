using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectGun : MonoBehaviour
{
	[SerializeField] private GameObject _gun;
	[SerializeField] private Transform _gunNode;

	private Button[] _buttons;

	private void Awake()
	{
		_buttons = GetComponentsInChildren<Button>();

		for (int i = 0; i < _buttons.Length; i++)
		{
			_buttons[i].onClick.AddListener(() => AddGun(_buttons[i].transform.localPosition));
		}
	}

	private void AddGun(Vector2 position)
	{
		Instantiate(_gun, _gunNode);

		_gun.transform.localPosition = new Vector2(position.x, position.y);
	}
}
