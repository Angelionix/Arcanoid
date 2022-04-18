using UnityEngine;

public class PaddleMover : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField]private Rigidbody2D rigidbodyPaddle;

    private void Awake()
    {
        InputKeyboard.moving += PaddleStrafe;
    }

    public void PaddleStrafe(Vector2 dir)
    {
        rigidbodyPaddle.velocity = dir * _speed;
    }

    private void OnDisable()
    {
        InputKeyboard.moving -= PaddleStrafe;
    }
}
