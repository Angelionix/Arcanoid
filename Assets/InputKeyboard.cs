using UnityEngine;

public class InputKeyboard : MonoBehaviour
{
    public delegate void MoveButtonPress(Vector2 dir);
    public static MoveButtonPress moveButtonpres;

    public delegate void BallLunche();
    public static BallLunche ballLunche;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveButtonpres(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveButtonpres(Vector2.right);
        }
        else
        {
             moveButtonpres(Vector2.zero);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ballLunche();
        }
    }
}
