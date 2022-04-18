using UnityEngine;

public class Baller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _posOnPaddle;
    [SerializeField] private SpriteRenderer _sp;

    [SerializeField] private Rigidbody2D _ballRigid;
    [SerializeField] private Rigidbody2D _paddleRigid;

    [SerializeField] private GameManager _gm;

    private bool _ballLunched = false;

    void FixedUpdate()
    {
         _ballRigid.velocity = _ballRigid.velocity.normalized *_speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BallDeath>() != null)
        {
            BallInitialisator();
            _gm.ChangeLives();
        }
    }

    public void BallStarter()
    {
        if (!_ballLunched)
        {
            float xVelocity = _paddleRigid.velocity.x;
            this.transform.SetParent(null);
            Vector2 direction = new Vector2(xVelocity, 1f);
            _ballRigid.simulated = true;
            _ballRigid.AddForce(direction*_speed);
            _ballLunched = true;
        }
    }

    public void BallInitialisator()
    {
        _ballLunched = false;
        _sp.enabled = false;
        _ballRigid.simulated = false;
        _ballRigid.velocity = Vector2.zero;
        this.transform.position = _posOnPaddle.position;
        this.transform.parent = _posOnPaddle.transform;
        _sp.enabled = true;
    }
}
