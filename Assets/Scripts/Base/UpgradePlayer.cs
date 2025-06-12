using UnityEngine;
using UnityEngine.UI;

public class UpgradePlayer : MonoBehaviour
{
    [SerializeField] private Transform _positionNode;

    private GameObject _player;
    private Canvas _canvas;
    private PlayerMove _playerMove;
    private Button _applyButton;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        _canvas = _player.GetComponentInChildren<Canvas>();
        _applyButton = _player.transform.Find("Gun").transform.Find("Canvas").transform.Find("ApplyButton").GetComponent<Button>();
        _applyButton.onClick.AddListener(ApplyChanges);

        _canvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerMove._rb.position = _positionNode.position;
            _playerMove._rb.rotation = 90;
            _playerMove.CanMove = false;
            _canvas.gameObject.SetActive(true);
            Camera.main.orthographicSize = 1;
        }
    }

    public void ApplyChanges()
    {
        _canvas.gameObject.SetActive(false);
        _playerMove.CanMove = true;
        Camera.main.orthographicSize = 3;
    }
}
