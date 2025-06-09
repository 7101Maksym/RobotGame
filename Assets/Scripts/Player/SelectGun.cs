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
    [Range(0, 360)]
    [SerializeField] public float StartDirection;

    public void AddGun()
    {
        _gun.transform.eulerAngles = new Vector3(0, 0, StartDirection - 90);

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
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + DirFromAngle(StartDirection, false));
    }

    Vector3 DirFromAngle(float angleInDegrees, bool global)
    {
        if (!global)
        {
            angleInDegrees += transform.eulerAngles.z;
        }

        float rad = angleInDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), transform.position.z);
    }
}
