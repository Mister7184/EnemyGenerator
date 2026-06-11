using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private bool _canMove;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_canMove == false)
            return;

        Vector2 newDirection = _rigidbody.position + _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(newDirection);
    }

    public void StartMove(Vector2 direction)
    {
        _canMove = true;

        _direction = direction.normalized;
    }

}