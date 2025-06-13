using UnityEngine;

public class RestorePack : MonoBehaviour
{
    public int _restore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<DamagedScript>().RestoreHealths(_restore);

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<EnemyDamagedScript>().RestoreHealths(_restore);

            Destroy(gameObject);
        }
    }
}
