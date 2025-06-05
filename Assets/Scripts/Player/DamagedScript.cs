using UnityEngine;

public class DamagedScript : MonoBehaviour
{
    private Animator _animator;

    public int myHealths, maxHealths;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (myHealths > 0)
        {
            _animator.SetInteger("DestrLewel", ((5 * myHealths) / maxHealths) + 1);
        }
        else
        {
            _animator.SetInteger("DestrLewel", 0);
            _animator.SetBool("IsDestroyed", true);
        }
    }
}
