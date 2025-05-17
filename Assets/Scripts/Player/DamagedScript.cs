using UnityEngine;

public class DamagedScript : MonoBehaviour
{
    [SerializeField] private Sprite _damaged_1;
    [SerializeField] private Sprite _damaged_2;
    [SerializeField] private Sprite _damaged_3;
    [SerializeField] private Sprite _damaged_4;
    [SerializeField] private Sprite _damaged_5;
    [SerializeField] private Sprite _damaged_6;
    private Sprite[] _textures = new Sprite[6];

    private SpriteRenderer _damageLewel;
    private Animator _animator;
    
    public int _myHealths, _maxHealths;

    private void Awake()
    {
        _damageLewel = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        _textures[0] = _damaged_6;
        _textures[1] = _damaged_5;
        _textures[2] = _damaged_4;
        _textures[3] = _damaged_3;
        _textures[4] = _damaged_2;
        _textures[5] = _damaged_1;
    }

    private void Update()
    {
        if (_myHealths != 0)
        {
            _damageLewel.sprite = _textures[(5 * _myHealths) / _maxHealths];
        }
        else
        {
            _animator.SetBool("IsDestroyed", true);
        }
    }
}
