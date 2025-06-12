using UnityEngine;

public class RotateGun : MonoBehaviour
{
	[SerializeField] private float _rotateSpeed = 50f;

	public float Limit;

	private ArtilleryLauncerShoot _shootScript;
	private PlayerMove _player;

	private int _direct;

    private void Awake()
    {
		Limit = gameObject.GetComponentInParent<SelectGun>().Limit;
        _shootScript = GetComponent<ArtilleryLauncerShoot>();
        _player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    private int GetRotateAngle()
	{
		Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float controlAngle;

        controlAngle = Vector2.Angle(transform.right.normalized, new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y).normalized);

        if (controlAngle < 89 && transform.localRotation.eulerAngles.z - 1 >= 0)
		{
			return -1;
		}
		else if (controlAngle > 91 && transform.localRotation.eulerAngles.z + 1 <= Limit)
		{
			return 1;
		}
		else
		{
			return 0;
		}
    }

	private void Update()
	{
		if (transform.localRotation.eulerAngles.z + 1 > Limit || transform.localRotation.eulerAngles.z - 1 < 0 || _direct != 0)
		{
			_shootScript.CanShoot = false;
		}
		else
		{
			if (_direct == 0)
			{
				_shootScript.CanShoot = true;
			}
		}
	}

    private void FixedUpdate()
    {
		if (_player.CanMove)
		{
			_direct = GetRotateAngle();

			transform.Rotate(new Vector3(0, 0, _rotateSpeed * _direct * Time.fixedDeltaTime));
		}
    }
}
