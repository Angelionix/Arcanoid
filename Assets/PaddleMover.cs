using UnityEngine;

public class PaddleMover : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField]private Rigidbody2D rigidbody;

    private void Awake()
    {
        InputKeyboard.moveButtonpres += PaddleStrafe;
    }
    public void PaddleStrafe(Vector2 dir)
    {
        rigidbody.velocity = dir * _speed;
    }
}
