using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayer : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private Transform _positionNode;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player._rb.position = _positionNode.position;
            _player._rb.rotation = 90;
            _player.CanMove = false;
        }
    }
}
