using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePack : MonoBehaviour
{
    public int _recharge;

    private void OnCollisionEnter2D(Collision2D collision)
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
