using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSettingObject : MonoBehaviour
{
    [SerializeField] private Transform _displayField;
    [SerializeField] private GameObject _displayedGun;
    [SerializeField] private SelectGun[] _gunSellecters;

    private GameObject _sprite;

    private void Awake()
    {
        _sprite = _displayedGun.transform.Find("Renderer").gameObject;

        _sprite.transform.localScale = new Vector3(13, 13, 13);

        Instantiate(_sprite, _displayField);
    }

    public void SetGun()
    {
        for (int i = 0; i < _gunSellecters.Length; i++)
        {
            _gunSellecters[i].Gun = _displayedGun;
        }
    }
}
