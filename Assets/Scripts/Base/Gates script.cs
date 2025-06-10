using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gatesscript : MonoBehaviour
{
    private Animator _animator;
    private PolygonCollider2D _closedCollider;
    private PolygonCollider2D _openedCollider;

    public bool Dangerous = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _closedCollider = gameObject.transform.Find("ClosedCollider").GetComponent<PolygonCollider2D>();
        _openedCollider = gameObject.transform.Find("OpenedCollider").GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (Dangerous)
        {
            _closedCollider.gameObject.SetActive(true);
            _openedCollider.gameObject.SetActive(false);
            _animator.SetBool("Dangerous", true);
        }
        else
        {
            _closedCollider.gameObject.SetActive(false);
            _openedCollider.gameObject.SetActive(true);
            _animator.SetBool("Dangerous", false);
        }
    }
}
