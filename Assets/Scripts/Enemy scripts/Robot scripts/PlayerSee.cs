using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSee : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

    private Enemy_script _enemyScript;

    private void Awake()
    {
        _enemyScript = GetComponent<Enemy_script>();
    }

    private void FixedUpdate()
    {
        if (_enemyScript.PlayerTransform)
        {
            if (Physics2D.Raycast(transform.position, _enemyScript.PlayerTransform.transform.position - transform.position, Vector2.Distance(_enemyScript.PlayerTransform.transform.position, transform.position), _mask))
            {
                _enemyScript.CanSee = false;
            }
            else
            {
                _enemyScript.CanSee = true;
            }
        }

        if (_enemyScript.RestorePackTransform)
        {
            if (Physics2D.Raycast(transform.position, _enemyScript.RestorePackTransform.transform.position - transform.position, Vector2.Distance(_enemyScript.RestorePackTransform.transform.position, transform.position), _mask))
            {
                _enemyScript.RestorePackCanSee = false;
            }
            else
            {
                _enemyScript.RestorePackCanSee = true;
            }
        }
    }
}
