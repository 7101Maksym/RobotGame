using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePack : MonoBehaviour
{
    [SerializeField] public int _recharge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<DamagedScript>().RechargeHealths(_recharge);

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<EnemyDamagedScript>().RechargeHealths(_recharge);

            Destroy(gameObject);
        }
    }
}
