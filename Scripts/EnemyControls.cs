using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IntRandom = System.Random;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private float _movePower;
    [SerializeField] private float _maxVelocity;
    private Rigidbody2D _rigidbody;
    private bool _isGoingRight;
    private static IntRandom _random = new();
    private Coroutine _changeDirection;

    private float _minChangeDirectionTime = 1;
    private float _maxChangeDirectionTime = 10;
    private float _changeDirectionTimer;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isGoingRight = (_random.Next(2) == 1);
        ChangeDirection();
    }
    
    private void Update()
    {
        if (_isGoingRight)
            MoveRight();
        else
            MoveLeft();
    }

    private void ChangeDirection()
    {
        _isGoingRight = !_isGoingRight;
        StartCoroutine(ChangeDirectionTimer());
    }

    private void MoveLeft()
    {
        if (_rigidbody.velocity.x >= -_maxVelocity)
            _rigidbody.velocity += Vector2.left * _movePower * Time.deltaTime;
    }

    private void MoveRight()
    {
        if (_rigidbody.velocity.x <= _maxVelocity)
            _rigidbody.velocity += Vector2.right * _movePower * Time.deltaTime;
    }

    private IEnumerator ChangeDirectionTimer()
    {
        yield return new WaitForSeconds(Random.Range(_minChangeDirectionTime, _maxChangeDirectionTime));
        ChangeDirection();
    }
}
