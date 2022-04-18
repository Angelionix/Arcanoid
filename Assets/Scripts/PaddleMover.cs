using UnityEngine;

public class PaddleMover : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField]private Rigidbody2D rigidbodyPaddle;

    private void Awake()
    {
        //rigidbodyPaddle = this.GetComponent<Rigidbody2D>();
    }
    public void PaddleStrafe(Vector2 dir)
    {
        rigidbodyPaddle.velocity = dir * _speed;
    }
}
