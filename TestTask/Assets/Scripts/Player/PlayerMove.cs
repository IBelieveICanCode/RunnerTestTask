using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private LayerMask _whatIsFloor;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float
        _speed = 5f,
        _acceleration = 1f,
        _jumpHeight = 30,
        _timeToAccelerate = 3;
    private Vector2
        _moveVector = Vector2.right,
        _verticalVector = new Vector2(0,5);
    private bool
        _allowToAccelerate = true;

    void Start()
    {
        Move();       
    }

    void FixedUpdate()
    {
        Accelerate();
        IsGrounded();
    }

    private void Move()
    {     
        _rb.AddForce(_moveVector * _speed, ForceMode2D.Impulse);
    }


    private void Accelerate()
    {
        if(_allowToAccelerate)
            StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        _allowToAccelerate = false;
        yield return new WaitForSeconds(_timeToAccelerate);
        _allowToAccelerate = true;
        if (IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x + _acceleration, _rb.velocity.y);
            _acceleration += 0.2f;
        }

    }
    public void Jump()
    {
        if(IsGrounded())
            _rb.AddForce(_verticalVector * _jumpHeight, ForceMode2D.Force);
    }

    private bool IsGrounded()
    {
       return Physics2D.OverlapCircle(transform.position, 0.5f, _whatIsFloor);
    }

    public int ReturnSpeed()
    {
        return Mathf.RoundToInt(_rb.velocity.magnitude);
    }

}
