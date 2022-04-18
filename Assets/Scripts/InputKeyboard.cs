using UnityEngine;

public class InputKeyboard : MonoBehaviour
{
    public delegate void Moving(Vector2 dir);
    public static Moving moving;

    public delegate void BallLunche();
    public static BallLunche ballLunching;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moving(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moving(Vector2.right);
        }
        else
        {
            moving(Vector2.zero);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ballLunching();
        }
    }
}
