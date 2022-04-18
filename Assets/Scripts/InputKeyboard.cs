using UnityEngine;

public class InputKeyboard : MonoBehaviour
{
    [SerializeField] private PaddleMover _mover;
    [SerializeField] private Baller _ball;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _mover.PaddleStrafe(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _mover.PaddleStrafe(Vector2.right);
        }
        else
        {
            _mover.PaddleStrafe(Vector2.zero);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _ball.BallStarter();
        }
    }
}
