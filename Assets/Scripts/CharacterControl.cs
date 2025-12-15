using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CharacterControl : MonoBehaviour
{
    //Is the player Input system
    [Header("Player")]
    [SerializeField] private float _maxSpeed = 20f;
    [SerializeField] private float _acceleration = 10f;
    
    private Rigidbody _rb;
    private float _turnInput;

    //Get the rigidbody
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    //Get the Input each time
    private void Update()
    {
        _turnInput = Input.GetAxis("Horizontal");
    }

    //Moves each time
    private void FixedUpdate()
    {
        Move();
    }
    
    //Elaborate movement
    private void Move()
    {
        Vector3 thrustForce = _turnInput * _acceleration * gameObject.transform.right;

        if (_rb.linearVelocity.magnitude >= _maxSpeed)
        {
            _rb.linearVelocity = _rb.linearVelocity.normalized * _maxSpeed;
        }
        else
        {
            _rb.AddForce(thrustForce, ForceMode.Acceleration);
        }

        if(_turnInput == 0)
        {
            float dragFactor = 0.6f;
            _rb.linearVelocity *= dragFactor;
        }
    }
}
