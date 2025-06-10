using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSee : MonoBehaviour
{
    [SerializeField] private Enemy_script _moveScript;
    [SerializeField] private LayerMask _mask;

    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, _player.transform.position - transform.position, Vector2.Distance(_player.transform.position, transform.position), _mask))
        {
            _moveScript._canSee = false;
        }
        else
        {
            _moveScript._canSee = true;
        }
    }
}
