using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private bool _canMove;
    private Transform _target;
    private Rigidbody2D _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void UseMove(Transform target)
    {
        _canMove = true;
        _target = target;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_canMove)
        {
            if (_target != null)
            {
                Vector2 newPosition = Vector2.MoveTowards(_rigidbody.position, _target.position, _speed * Time.fixedDeltaTime);

                _rigidbody.MovePosition(newPosition);
            }

            yield return null;
        }
    }
}