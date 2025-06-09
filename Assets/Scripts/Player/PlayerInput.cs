using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float UpDown { get; private set; }
    public float LeftRight { get; private set; }
    public float Shoot { get; private set; }

    private void Update()
    {
        UpDown = Input.GetAxisRaw("Vertical");
        LeftRight = Input.GetAxisRaw("Horizontal");
        Shoot = Input.GetAxisRaw("Fire1");
    }
}
