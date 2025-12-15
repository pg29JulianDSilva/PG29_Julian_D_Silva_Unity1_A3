using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("ProjectileData")]
    [SerializeField] protected float _speed = 15f;
    [SerializeField] private float _spinForce = 0f;

    protected Rigidbody _rigidbody;

    //It gives the speed to the projectile
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.linearVelocity = _speed * gameObject.transform.forward;

        if(_spinForce > 0f) _rigidbody.AddTorque(_spinForce * Random.insideUnitSphere);
    }
}
