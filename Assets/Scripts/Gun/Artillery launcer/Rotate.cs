using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField] private float _rotateSpeed = 50f;

	[SerializeField] private Rigidbody2D _rb;

	private float _rotateAngle;

	private int _direct;
    private int GetRotateAngle()
	{
		Vector2 mouse = Input.mousePosition;

		float controlAngle;

		_rotateAngle = Vector2.Angle(transform.up, new Vector2(transform.position.x - mouse.x, transform.position.y - mouse.y));
		controlAngle = Vector2.Angle(transform.right, new Vector2(transform.position.x - mouse.x, transform.position.y - mouse.y));

		if (controlAngle < 89)
		{
			return 1;
		}
		else if (controlAngle > 91)
		{
			return -1;
		}
		else
		{
			return 0;
		}
    }

    private void FixedUpdate()
    {
		_direct = GetRotateAngle();
		//_rotateSpeed * _direct * Time.fixedDeltaTime
		_rb.rotation = _rotateAngle * _direct;
    }
}
