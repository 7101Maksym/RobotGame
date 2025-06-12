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
        else if (collision.gameObject.CompareTag("Recharge"))
        {
            _moveScript.RechargePackFinded = true;
            _moveScript.RechargePackTransform = collision.GetComponentInParent<Rigidbody2D>().transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _moveScript.PlayerFinded = false;
        }
        else if (collision.gameObject.CompareTag("Recharge"))
        {
            _moveScript.RechargePackFinded = false;
        }
    }
}
