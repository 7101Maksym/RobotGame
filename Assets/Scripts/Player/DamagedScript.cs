using UnityEngine;

public class DamagedScript : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private int _maxHealths;

    public int myHealths;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (myHealths > 0)
        {
            _animator.SetInteger("DestrLewel", ((5 * myHealths) / _maxHealths) + 1);
        }
        else
        {
            _animator.SetInteger("DestrLewel", 0);
            _animator.SetBool("IsDestroyed", true);
        }
    }

    public void RestoreHealths(int restore)
    {
        if (myHealths == _maxHealths)
        {
            return;
        }
        else if (myHealths + restore >= _maxHealths)
        {
            myHealths = _maxHealths;
        }
        else
        {
            myHealths += restore;
        }
    }
}
