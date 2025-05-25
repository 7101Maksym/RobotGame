using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float up_down { get; private set; }
    public float left_right { get; private set; }

    private void Update()
    {
        up_down = Input.GetAxisRaw("Vertical");
        left_right = Input.GetAxisRaw("Horizontal");
    }
}
