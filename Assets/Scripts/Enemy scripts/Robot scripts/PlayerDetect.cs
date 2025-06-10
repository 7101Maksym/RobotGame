using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private Enemy_script _moveScript;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Base"))
        {
            _moveScript._playerFinded = true;
            _moveScript._playerTransform = collision.GetComponentInParent<Rigidbody2D>().transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Base"))
        {
            _moveScript._playerFinded = false;
        }
    }
}
