using UnityEngine;
using UnityEngine.UI;

public class SelectGun : MonoBehaviour
{
	[SerializeField] public GameObject Gun;
    
    [Range(0, 360)]
    [SerializeField] public float Limit;
    [Range(0, 360)]
    [SerializeField] public float StartDirection;
    
    private Image _image;

    private char _id;

    private void Awake()
    {
        _id = transform.name[transform.name.Length - 1];

        _image = GameObject.Find("Canvas").transform.Find("SettingButtons").transform.Find("Button " + _id).GetComponent<Image>();
    }

    public void AddGun()
    {
        Gun.transform.eulerAngles = new Vector3(0, 0, StartDirection - 90);

        Instantiate(Gun, gameObject.transform);

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
