using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private Enemy_script _moveScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _moveScript._playerFinded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _moveScript._playerFinded = false;
        }
    }
}
