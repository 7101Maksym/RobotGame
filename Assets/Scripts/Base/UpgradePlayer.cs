using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePlayer : MonoBehaviour
{
	[SerializeField] private Transform _positionNode;

	private GameObject _player;
	private Canvas _canvas;
	private PlayerMove _playerMove;
	private Button _applyButton;
	private CinemachineVirtualCamera _camera;

	private void Awake()
	{
		_player = GameObject.Find("Player");
		_playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
		_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		_applyButton = GameObject.Find("Canvas").transform.Find("ApplyButton").GetComponent<Button>();
		_applyButton.onClick.AddListener(ApplyChanges);
		_camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();

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
			_camera.m_Lens.OrthographicSize = 1;
			_camera.m_Lens.Dutch = 90;
		}
	}

	public void ApplyChanges()
	{
		_canvas.gameObject.SetActive(false);
		_playerMove.CanMove = true;
		_camera.m_Lens.OrthographicSize = 3;
		_camera.m_Lens.Dutch = 0;
	}
}
