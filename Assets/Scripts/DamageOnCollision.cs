using System;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    //This for the collision of the non taged elements
    [Header("CollisionElements")]
    [SerializeField] private int _team = 0;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _minVelocity = 5f;
    [SerializeField] private bool _destroyOnCollision = false;

    //set teams if necesary
    private void Start()
    {
        if(gameObject.TryGetComponent(out invidersAI target) == true)
        {
            target._teams = _team;
        }
    }

    ///detect the damage
    private void OnTriggerEnter(Collider other)
    {
        TryDamage(other);
    }

    //Checks collision in range
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > _minVelocity)
        {
            TryDamage(collision.collider);
        }
    }

    private void TryDamage(Collider collider)
    {
        //THis is changes where the player is 0, which means it can be damage for any collision, but the enemies can only be damged by a specific team
        if ((collider.TryGetComponent(out Health target) == true && target.Team == _team))
        {
            target.ApplyDamage(_damage);
            if (_destroyOnCollision) Destroy(gameObject);
        }

        //Checks in case there is no health component (bullets and inviders)
        if ((collider.TryGetComponent(out DamageOnCollision damaged) == true && damaged._team == _team))
        {
            if (_destroyOnCollision) Destroy(gameObject);
        }


    }
}
