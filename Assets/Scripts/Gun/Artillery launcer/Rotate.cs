using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField] private float _rotateSpeed = 50f;

	public float Limit;

	private int _direct;

    private void Awake()
    {
		Limit = gameObject.GetComponentInParent<SelectGun>().Limit;
    }

    private int GetRotateAngle()
	{
		Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float controlAngle;
		Debug.Log(transform.rotation.eulerAngles.z);
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

    private void FixedUpdate()
    {
		_direct = GetRotateAngle();
		transform.Rotate(new Vector3(0, 0, _rotateSpeed * _direct * Time.fixedDeltaTime));
    }
}
