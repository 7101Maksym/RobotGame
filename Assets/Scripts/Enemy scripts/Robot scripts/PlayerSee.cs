using UnityEngine;

public class PlayerSee : MonoBehaviour
{
    [SerializeField] private Enemy_script _moveScript;

    private int _countObgects;

    private void Awake()
    {
        _moveScript = GetComponentInParent<Enemy_script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            _countObgects++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            _countObgects--;
        }
    }

    private void Update()
    {
        if (_countObgects > 0)
        {
            _moveScript._canSee = false;
        }
        else
        {
            _moveScript._canSee = true;
        }
    }
}
