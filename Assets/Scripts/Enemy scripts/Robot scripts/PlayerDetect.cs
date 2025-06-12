using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private Enemy_script _moveScript;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _moveScript.PlayerFinded = true;
            _moveScript.PlayerTransform = collision.GetComponentInParent<Rigidbody2D>().transform;
        }
        else if (collision.gameObject.CompareTag("Restore"))
        {
            _moveScript.RestorePackFinded = true;
            _moveScript.RestorePackTransform = collision.GetComponentInParent<Rigidbody2D>().transform;
            _moveScript.SetDeathZone = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _moveScript.PlayerFinded = false;
        }
        else if (collision.gameObject.CompareTag("Restore"))
        {
            _moveScript.RestorePackFinded = false;
            _moveScript.SetDeathZone = true;
        }
    }
}
