using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectGun : MonoBehaviour
{
	[SerializeField] private GameObject _gun;
    [SerializeField] private Image _image;

    public void AddGun()
    {
        Instantiate(_gun, gameObject.transform);

        _image.gameObject.SetActive(false);
    }
}
