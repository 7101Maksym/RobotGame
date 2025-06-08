using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SelectGun : MonoBehaviour
{
	[SerializeField] private GameObject _gun;
    [SerializeField] private Image _image;

    [Range(0, 360)]
    [SerializeField] public float Limit;

    public void AddGun()
    {
        Instantiate(_gun, gameObject.transform);

        _image.gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1);

        Vector3 leftBoundary = DirFromAngle(90, false);
        Vector3 rightBoundary = DirFromAngle(Limit + 90, false);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary * 1);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary * 1);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 1);
    }

    Vector2 DirFromAngle(float angleInDegrees, bool global)
    {
        if (!global)
        {
            angleInDegrees += transform.eulerAngles.z;
        }

        float rad = angleInDegrees * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }
}
