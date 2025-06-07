using UnityEngine;

public class Test : MonoBehaviour
{
    public void Void()
    {
        Debug.Log("void");
    }

    public void V2(Vector2 a)
    {
        Debug.Log(a);
    }

    public void Int(int a)
    {
        Debug.Log(a);
    }

    private void Awake()
    {
        
    }
}
